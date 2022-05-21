using System;
using System.Collections.Generic;
using System.Linq;

namespace JSONExtractor
{
    /// <summary>
    /// I'm trying to keep JSONExtractor "generic" for use by anyone trying to
    /// query large sets of JSON, but occasionally I'm going to optimize a 
    /// corner-case for spectroscopy.  In those cases, where the function is
    /// clearly not of interest to users from other domains, I'll try to 
    /// squirrel away the custom features here.
    /// </summary>
    internal class SpectrumUtil
    {
        public class WavecalGenerator
        {
            public string wavecalJsonPath;
            public string excitationJsonPath;

            Logger logger = Logger.getInstance();

            /// <summary>
            /// Called by GUI when user adds a new ExtractAttribute with interpolation enabled.
            /// At that point, all we know are the paths to the wavecal and excitation in
            /// the JSON structure; we won't have access to actual values until we're 
            /// processing individual records in the extract.
            /// </summary>
            public WavecalGenerator(string wavecalJsonPath, string excitationJsonPath)
            {
                this.wavecalJsonPath = wavecalJsonPath;
                this.excitationJsonPath = excitationJsonPath;
            }                

            public List<double> generateAxis(IDictionary<string, object> jsonRoot, int pixels)
            {
                // render wavelengths using the polynomial
                List<double> coeffs = getCoeffs(jsonRoot, wavecalJsonPath);
                if (coeffs is null)
                    return null;

                List<double> axis = new(pixels);
                for (int i = 0; i < pixels; i++)
                    axis.Add(evaluatePolynomial(i, coeffs));

                // check if we have a configured excitation
                var obj = Util.getJsonValue(jsonRoot, excitationJsonPath);
                if (obj != null)
                {
                    // convert axis to wavenumbers (don't bother retaining wavelengths)
                    double excitationNM = Util.toDouble(obj);
                    for (int i = 0; i < pixels; i++)
                        axis[i] = wavelengthToWavenumber(axis[i], excitationNM);
                }

                return axis;
            }

            public string getLabel() => excitationJsonPath is null ? "wavelength" : "wavenumber";

            List<double> getCoeffs(IDictionary<string, object> jsonRoot, string wavecalJsonPath)
            {
                var value = Util.getJsonValue(jsonRoot, wavecalJsonPath);
                if (value is null)
                    return null;

                var values = Util.forceDouble((List<object>)value);
                if (values.Count == 0)
                    return null;

                return values;
            }
        }

        public static double wavelengthToWavenumber(double wavelengthNM, double laserWavelengthNM)
        {
            const double NM_TO_CM = 1.0 / 10000000.0;
            return 1.0 / (laserWavelengthNM * NM_TO_CM) - (1.0 / (wavelengthNM * NM_TO_CM));
        }   

        /// <remarks>
        /// compromise between length, performance and reusability 
        /// (most calibrations are 2nd-to-4th order)
        /// </remarks>
        public static double evaluatePolynomial(int x, List<double> coeffs)
        {
            double result = 0;
            if (coeffs.Count >= 1) result  = coeffs[0];
            if (coeffs.Count >= 2) result += coeffs[1] * x;
            if (coeffs.Count >= 3) result += coeffs[2] * coeffs[2] * x;
            if (coeffs.Count >= 4) result += coeffs[3] * coeffs[3] * coeffs[3] * x;
            if (coeffs.Count >= 5) result += coeffs[4] * coeffs[4] * coeffs[4] * coeffs[4]  * x;
            for (int i = 5; i < coeffs.Count; i++)
                result += x * Math.Pow(coeffs[i], i);
            return result;
        }
    }
}
