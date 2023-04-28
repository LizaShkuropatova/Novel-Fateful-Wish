// This code is part of the Fungus library (https://github.com/snozbot/fungus)
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

/*This script has been, partially or completely, generated by the Fungus.GenerateVariableWindow*/
using UnityEngine;

namespace Fungus
{
    // <summary>
    /// Get or Set a property of a Texture2D component
    /// </summary>
    [CommandInfo("Property",
                 "Texture2D",
                 "Get or Set a property of a Texture2D component")]
    [AddComponentMenu("")]
    public class Texture2DProperty : BaseVariableProperty
    {
		//generated property
        public enum Property 
        { 
            IgnoreMipmapLimit, 
            IsReadable, 
            VtOnly, 
            StreamingMipmaps, 
            StreamingMipmapsPriority, 
            RequestedMipmapLevel, 
            MinimumMipmapLevel, 
            CalculatedMipmapLevel, 
            DesiredMipmapLevel, 
            LoadingMipmapLevel, 
            LoadedMipmapLevel, 
            AlphaIsTransparency, 
        }


        [SerializeField]
        protected Property property;

        [SerializeField]
        protected Texture2DData texture2DData;

        [SerializeField]
        [VariableProperty(typeof(BooleanVariable),
                          typeof(IntegerVariable))]
        protected Variable inOutVar;

        public override void OnEnter()
        {
            var iob = inOutVar as BooleanVariable;
            var ioi = inOutVar as IntegerVariable;


            var target = texture2DData.Value;

            switch (getOrSet)
            {
                case GetSet.Get:
                    switch (property)
                    {
                        case Property.IgnoreMipmapLimit:
                            iob.Value = target.ignoreMipmapLimit;
                            break;
                        case Property.IsReadable:
                            iob.Value = target.isReadable;
                            break;
                        case Property.VtOnly:
                            iob.Value = target.vtOnly;
                            break;
                        case Property.StreamingMipmaps:
                            iob.Value = target.streamingMipmaps;
                            break;
                        case Property.StreamingMipmapsPriority:
                            ioi.Value = target.streamingMipmapsPriority;
                            break;
                        case Property.RequestedMipmapLevel:
                            ioi.Value = target.requestedMipmapLevel;
                            break;
                        case Property.MinimumMipmapLevel:
                            ioi.Value = target.minimumMipmapLevel;
                            break;
                        case Property.CalculatedMipmapLevel:
                            ioi.Value = target.calculatedMipmapLevel;
                            break;
                        case Property.DesiredMipmapLevel:
                            ioi.Value = target.desiredMipmapLevel;
                            break;
                        case Property.LoadingMipmapLevel:
                            ioi.Value = target.loadingMipmapLevel;
                            break;
                        case Property.LoadedMipmapLevel:
                            ioi.Value = target.loadedMipmapLevel;
                            break;
                        case Property.AlphaIsTransparency:
                            iob.Value = target.alphaIsTransparency;
                            break;
                        default:
                            Debug.Log("Unsupported get or set attempted");
                            break;
                    }

                    break;

                case GetSet.Set:
                    switch (property)
                    {
                        case Property.IgnoreMipmapLimit:
                            target.ignoreMipmapLimit = iob.Value;
                            break;
                        case Property.RequestedMipmapLevel:
                            target.requestedMipmapLevel = ioi.Value;
                            break;
                        case Property.MinimumMipmapLevel:
                            target.minimumMipmapLevel = ioi.Value;
                            break;
                        case Property.AlphaIsTransparency:
                            target.alphaIsTransparency = iob.Value;
                            break;
                        default:
                            Debug.Log("Unsupported get or set attempted");
                            break;
                    }

                    break;

                default:
                    break;
            }

            texture2DData.Value = target;

            Continue();
        }

        public override string GetSummary()
        {
            if (texture2DData.Value == null)
            {
                return "Error: no texture2D set";
            }
            if (inOutVar == null)
            {
                return "Error: no variable set to push or pull data to or from";
            }

            return getOrSet.ToString() + " " + property.ToString();
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }

        public override bool HasReference(Variable variable)
        {
            if (texture2DData.texture2DRef == variable || inOutVar == variable)
                return true;

            return false;
        }
    }
}