using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Google;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirebaseGoogleLogin : MonoBehaviour
{
    public string GoogleWebAPI = "648889518880-gjasdeqssudfpkrai4v934lcvrd13o0d.apps.googleusercontent.com";

    private GoogleSignInConfiguration configuration;

    Firebase.DependencyStatus dependencyStatus = Firebase.DependencyStatus.UnavailableOther;
    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser currentUser;
    private DatabaseReference databaseRef;
    private string userId;

    public Button GoogleButton;
    public Button LogOutButton;
    public TMPro.TMP_Text TextLogIn;
    public TMPro.TMP_Text TextEmail;
    public TMPro.TMP_Text TextUID;
    public TMPro.TMP_Text UserEmail;
    public TMPro.TMP_Text UID;


    private void Awake()
    {
        configuration = new GoogleSignInConfiguration
        {
            WebClientId = GoogleWebAPI,
            RequestIdToken = true
        };
    }

    private void Start()
    {
        // ������������� Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Failed to initialize Firebase: " + task.Result.ToString());
            }
        });

        // ���������� ������������ ������� ������
        GoogleButton.onClick.AddListener(OnGoogleButtonClicked);
        LogOutButton.onClick.AddListener(OnLogOutButtonClicked);

        // ��������, ����������� �� ������������ ��� ������� ����������
        if (auth.CurrentUser != null)
        {
            OnUserLoggedIn(auth.CurrentUser.Email, auth.CurrentUser.UserId);
        }
    }

    private void InitializeFirebase()
    {
        // ������������� �������������� � ���� ������ Firebase
        auth = FirebaseAuth.DefaultInstance;
        databaseRef = FirebaseDatabase.DefaultInstance.RootReference;

        // ��������, ����������� �� ������������ ��� ������� ����������
        if (auth.CurrentUser != null)
        {
            OnUserLoggedIn(auth.CurrentUser.Email, auth.CurrentUser.UserId);
        }
        else
        {
            LogOutButton.gameObject.SetActive(false); // �������� ������ LogOutButton
        }
    }

    private void OnGoogleButtonClicked()
    {
        // ����� ������ ����������� ����� Google
        GoogleSignInAsync();
    }

    private void GoogleSignInAsync()
    {
        GoogleSignIn.Configuration = configuration;
        GoogleSignIn.Configuration.UseGameSignIn = false;
        GoogleSignIn.Configuration.RequestIdToken = true;
        GoogleSignIn.Configuration.RequestEmail = true;

        GoogleSignIn.DefaultInstance.SignIn().ContinueWith(OnAuthenticationFinished);
    }

    private void OnAuthenticationFinished(Task<GoogleSignInUser> task)
    {
        if (task.IsFaulted)
        {
            Debug.LogError("Google sign-in failed: " + task.Exception);
            return;
        }

        GoogleSignInUser signInUser = task.Result;
        Credential credential = GoogleAuthProvider.GetCredential(signInUser.IdToken, null);

        auth.SignInWithCredentialAsync(credential).ContinueWith(authTask =>
        {
            if (authTask.IsCanceled || authTask.IsFaulted)
            {
                Debug.LogError("Google sign-in failed: " + authTask.Exception);
                return;
            }

            // �������� �����������
            FirebaseUser user = authTask.Result;
            OnUserLoggedIn(user.Email, user.UserId);
        });
    }

    private void OnUserLoggedIn(string email, string uid)
    {
        // ���������� UI ����� �������� �����������
        LogOutButton.gameObject.SetActive(true);
        GoogleButton.gameObject.SetActive(false);
        TextLogIn.gameObject.SetActive(false);
        UserEmail.text = email;
        UID.text = uid;

        // ���������� ������ � ���� ������ Firebase
        userId = uid;
        databaseRef.Child("users").Child(userId).Child("email").SetValueAsync(email);
        databaseRef.Child("users").Child(userId).Child("uid").SetValueAsync(uid);
    }

    private void OnLogOutButtonClicked()
    {
        // ����� �� ��������
        auth.SignOut();

        // ���������� UI ����� ������ �� ��������
        LogOutButton.gameObject.SetActive(false);
        GoogleButton.gameObject.SetActive(true);
        TextLogIn.gameObject.SetActive(true);
        UserEmail.text = string.Empty;
        UID.text = string.Empty;
    }

    // ����� ��� ���������� ���������� �� Flowchart � ���� ������ Firebase
    public void SaveVariables(int chapter, int diplomacy, int resistance, int reputation, int demid, int demidRomance)
    {
        if (userId != null)
        {
            databaseRef.Child("users").Child(userId).Child("chapter").SetValueAsync(chapter);
            databaseRef.Child("users").Child(userId).Child("diplomacy").SetValueAsync(diplomacy);
            databaseRef.Child("users").Child(userId).Child("resistance").SetValueAsync(resistance);
            databaseRef.Child("users").Child(userId).Child("reputation").SetValueAsync(reputation);
            databaseRef.Child("users").Child(userId).Child("demid").SetValueAsync(demid);
            databaseRef.Child("users").Child(userId).Child("demidRomance").SetValueAsync(demidRomance);
        }
    }
}
