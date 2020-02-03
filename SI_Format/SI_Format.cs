// Maintain this file in UTF-8 coding
using System;

namespace InfoReg_SI
{

    /// <summary>
    ///     Physical constants may be referenced unsing this class.
    ///     Please see https://physics.nist.gov/cuu/Constants/
    /// </summary>
    public static class Physical_Constants
    {
        // Values obtained at https://physics.nist.gov/cuu/Constants/
        // length meter m 
        // mass kilogram kg
        // time second s
        // electric current ampere A
        // thermodynamic temperature kelvin K
        // amount of substance mol
        // luminous intensity candela cd
        //

        // Universal physical constants
        /// <summary>
        /// LightSpeed is the spped of light in a vacuum.
        /// </summary>
        public const Double LightSpeed = 299792458.0; // m/s
        /// <summary>
        /// GravitationalConstant is the gravitational constant
        /// </summary>
        public const Double GravitationalConstant = 6.67430e-11; // cubic-metres/(kilo-gram (second squared))
        /// <summary>
        /// PlanckConstant is Plank's constant
        /// </summary>
        public const Double PlanckConstant = 6.62607015e-34; // J / s
        /// <summary>
        /// ReducedPlankConstant is the reduced Plank's constant
        /// </summary>
        public const Double ReducedPlankConstant = 1.0545718e-34; // J / Hz
        /// <summary>
        /// MagneticConstant is the magnetic constant
        /// </summary>
        public const Double MagneticConstant = 1.25663706212e-6; // Neutons/sqaure Amp
        /// <summary>
        /// ElectricConstant is the electric constant
        /// </summary>
        public const Double ElectricConstant = 8.8541878128e-12; // Farads/metre
                                                                 // Electromagnetic constant
        /// <summary>
        /// MagneticFluxQuantum is the quantum magnetic flux constant
        /// </summary>
        public const Double MagneticFluxQuantum = 2.067833831e-15; // Wb
        /// <summary>
        /// ElementaryCharge is the elementary charge constant
        /// </summary>
        public const Double ElementaryCharge = 1.602176634e-19; // C
        /// <summary>
        /// ElementaryCharge is the quantum conductance constant
        /// </summary>
        public const Double ConductanceQuantum = 7.748091729e-5; // S
                                                                 // Atomic and nuclear
        /// <summary>
        /// ElectronMass is the mass of an electron
        /// </summary>
        public const Double ElectronMass = 9.1093837015e-31; // kg
        /// <summary>
        /// ProtonMass is the mass of a proton
        /// </summary>
        public const Double ProtonMass = 1.67262192369e-27; // kg
        /// <summary>
        /// FineStructureConstant is the fine structure constant
        /// </summary>
        public const Double FineStructureConstant = 7.2973525693e-3;
        /// <summary>
        /// RydbergConstant is the Rydberg constant
        /// </summary>
        public const Double RydbergConstant = 10973731.568160; // per metre
        /// <summary>
        /// BohrRadius is the Bohr radius constant
        /// </summary>
        public const Double BohrRadius = 5.29177210903e-11; // m
        /// <summary>
        /// ClassicalElectronRadius is the classical electron radius constant
        /// </summary>
        public const Double ClassicalElectronRadius = 2.8179403262e-15; // m
                                                                        // Physio-chemical constants
        /// <summary>
        /// AtomicMassUnit is the atomic mass unit constant
        /// </summary>
        public const Double AtomicMassUnit = 1.66053906660e-27; // kg
        /// <summary>
        /// AvogadroConstant is the Avogadro constant
        /// </summary>
        public const Double AvogadroConstant = 6.02214076e-23; // per mol
        /// <summary>
        /// FaradayConstant is the Faraday constant
        /// </summary>
        public const Double FaradayConstant = 96485.33212; // C/mol
        /// <summary>
        /// MolarGasConstant is the Molar Gas Constant
        /// </summary>
        public const Double MolarGasConstant = 8.314462618; // J/(mol K)
        /// <summary>
        /// BoltzmannConstant is the Boltzmann's constant
        /// </summary>
        public const Double BoltzmannConstant = 1.380649 - 23; // J/K
        /// <summary>
        /// Stefan_BoltzmannConstant is the Stefan_Boltzmann's constant
        /// </summary>
        public const Double Stefan_BoltzmannConstant = 5.670374419e-8; // W m^-2 K^-4
                                                                       // Other commonly us
        /// <summary>
        /// ElectronVolt is an electron volt
        /// </summary>
        public const Double ElectronVolt = 1.602176634e-19; // J
        /// <summary>
        /// StandardGravity rate of accelleration due to gravity on Earth
        /// </summary>
        public const Double StandardGravity = 9.80665; // m/s/s
        /// <summary>
        /// Pi is the value of the pi constant i.e. numer of radii to make a semi circle based on that radius
        /// </summary>
        public const Double Pi = 3.14159265359;
        /// <summary>
        /// NaturalLogBase the base used for natural logs
        /// </summary>
        public const Double NaturalLogBase = 2.71828182846;
    }

    /// <summary>
    /// Format is a class that contains functions to adjust or parse numbers to and from
    /// strings like 10pF or 123.46 kilo-metres oe 65.123 ml.
    /// </summary>
    static public class Format
    {

        /// <summary>
        /// Returns values in text in SI format. An example is 123.45km.
        /// It takes a double value and looks at its decimal exponent. The exponent 
        /// is reduced to its residue three value. It then prefixes the unit
        /// passed in with the appropriate SI prefix.
        /// 
        /// "yotta-", "zetta-", "exa-", "peta-", "tera-", "giga-", "mega-", "kilo",
        /// "", "milli-", "micro-", "nano-", "pico-", "femto-", "atto-", "zepto-", "yocto-"
        /// 
        /// If siunit is two or less characters the return will use short SI
        /// prefixes like:
        /// "Y", "Z", "E", "P", "T", "G", "M", "k",
        /// "", "m", "μ", "n", "p", "f", "a", "z", "y"
        /// 
        /// No prefix is needed for the d_val lies in the range 0.0 to just under 1000.0.
        /// 
        /// Note: hecto, deca, deci, and centi are not supported.
        ///       SI does not support numbers above 10^27 or below 10^-24 
        ///       and any such value will be returned unmodified without SI prefix units.
        /// </summary>
        /// <param name="d_val">A double value to be SI normalized.</param>
        /// <param name="sformat">Is the format string usually based on G or N </param>
        /// <param name="siunit">An SI unit like watt, metre or l</param>
        /// <returns>Formatted string e.g. "9.46 peta-metres"</returns>
        static public String SI_Format(double d_val, String sformat, String siunit)
        {
            // Note: hecto, deca, deci, and centi are not supported
            // si does not support numbers above 10^27 or below 10^-24 
            // return unmodified without SI prefix units
            Double exp;
            exp = Math.Log10(d_val);
            if (exp >= 27.0 || exp <= -24.0)
            {
                return (String.Format("{0:" + sformat + "} {1}", d_val, siunit));
            }
            else
            {
                Int32 exp1 = (((Int32)exp / 3) * 3);
                Int32 adjust = 8; // Array element for no SI prefix
                if (exp < 0)
                {
                    exp1 -= 3;
                }
                Double dval = d_val / Math.Pow(10.0, (double)exp1);
                if (siunit.Length >= 3)
                {
                    String[] si_prefixes = { "yotta-", "zetta-", "exa-", "peta-", "tera-", "giga-", "mega-", "kilo",
                        "", "milli-", "micro-", "nano-", "pico-", "femto-", "atto-", "zepto-", "yocto-" };
                    return (String.Format("{0:" + sformat + "} ", dval) + si_prefixes[-(exp1 / 3) + adjust] + siunit);
                }
                else
                {
                    String[] si_prefixes = { "Y", "Z", "E", "P", "T", "G", "M", "k",
                        "", "m", "μ", "n", "p", "f", "a", "z", "y" };
                    return (String.Format("{0:" + sformat + "} ", dval) + si_prefixes[-(exp1 / 3) + adjust] + siunit);
                }
            }
        }

        /// <summary>
        /// This converts the float to a double and uses the 
        /// SI_Format(Double d_val, String sformat, String siunit) function.
        /// Returns values in a text SI format. An example is 123.45km.
        /// It takes a float value and looks at its decimal exponent. The exponent 
        /// is reduced to its residue three value. It then prefixes the unit
        /// passed in with the appropriate SI prefix.
        /// 
        /// "yotta-", "zetta-", "exa-", "peta-", "tera-", "giga-", "mega-", "kilo",
        /// "", "milli-", "micro-", "nano-", "pico-", "femto-", "atto-", "zepto-", "yocto-"
        /// 
        /// If siunit is two or less characters the return will use short SI
        /// prefixes like:
        /// "Y", "Z", "E", "P", "T", "G", "M", "k",
        /// "", "m", "μ", "n", "p", "f", "a", "z", "y"
        /// 
        /// No prefix is needed for the d_val lies in the range 0.0 to just under 1000.0.
        /// 
        /// Note: hecto, deca, deci, and centi are not supported.
        ///       SI does not support numbers above 10^27 or below 10^-24 
        ///       and any such value will be returned unmodified without SI prefix units.
        /// </summary>
        /// <param name="f_val">A float value to be SI normalized.</param>
        /// <param name="sformat">Is the format string usually based on G or N </param>
        /// <param name="siunit">An SI unit like watt, metre or l</param>
        /// <returns>Formatted string e.g. "9.46 peta-metres"</returns>

        static public String SI_Format(float f_val, String sformat, String siunit)
        {
            Double val = (Double)f_val;
            return (SI_Format(val, sformat, siunit));
        }

        /// <summary>
        /// Returns values in text in SI format. An example is 123.45km.
        /// It takes a decimal value and looks at its decimal exponent. The exponent 
        /// is reduced to its residue three value. It then prefixes the unit
        /// passed in with the appropriate SI prefix.
        /// 
        /// "yotta-", "zetta-", "exa-", "peta-", "tera-", "giga-", "mega-", "kilo",
        /// "", "milli-", "micro-", "nano-", "pico-", "femto-", "atto-", "zepto-", "yocto-"
        /// 
        /// If siunit is two or less characters the return will use short SI
        /// prefixes like:
        /// "Y", "Z", "E", "P", "T", "G", "M", "k",
        /// "", "m", "μ", "n", "p", "f", "a", "z", "y"
        /// 
        /// No prefix is needed for the d_val lies in the range 0.0 to just under 1000.0.
        /// 
        /// Note: hecto, deca, deci, and centi are not supported.
        ///       SI does not support numbers above 10^27 or below 10^-24 
        ///       and any such value will be returned unmodified without SI prefix units.
        /// </summary>
        /// <param name="decimal_val">A decimal value to be SI normalized.</param>
        /// <param name="sformat">Is the format string usually based on G or N </param>
        /// <param name="siunit">An SI unit like watt, metre or l</param>
        /// <returns>Formatted string e.g. "9.46 pm"</returns>


        static public String SI_Format(Decimal decimal_val, String sformat, String siunit)
        {
            Double exp = Math.Log10((Double)decimal_val);
            if (exp >= 27.0 || exp <= -24.0)
            {
                return (String.Format("{0:" + sformat + "} {1}", decimal_val, siunit));
            }
            else
            {
                Int32 exp1 = (((Int32)exp / 3) * 3);
                Int32 adjust = 8;  // Array element for no SI prefix
                if (exp < 0)
                {
                    exp1 -= 3;
                }
                Decimal decimal_val1 = decimal_val / (Decimal)Math.Pow(10.0, (double)exp1);
                if (siunit.Length >= 3)
                {
                    String[] si_prefixes = { "yotta-", "zetta-", "exa-", "peta-", "tera-", "giga-", "mega-", "kilo-",
                        "", "milli-", "micro-", "nano-", "pico-", "femto-", "atto-", "zepto-", "yocto-" };
                    return (String.Format("{0:" + sformat + "} ", decimal_val1) + si_prefixes[-(exp1 / 3) + adjust] + siunit);
                }
                else
                {
                    String[] si_prefixes = { "Y", "Z", "E", "P", "T", "G", "M", "k",
                        "", "m", "μ", "n", "p", "f", "a", "z", "y" };
                    return (String.Format("{0:" + sformat + "} ", decimal_val1) + si_prefixes[-(exp1 / 3) + adjust] + siunit);
                }
            }
        }

        /// <summary>
        /// Takes an SI formatted value like "12.34 km" and returns a double with the
        /// value 1.234e4. A String "10pF" would be returned as a double value 1e-11.
        /// </summary>
        /// <param name="si_value">A string value like 12.345MHz</param>
        /// <param name="dnum">A double that will be assigned the parsed value from the SI formatted string</param>
        /// <returns>A double value adjusted for the SI prefix value.</returns>
        static public void SI_Parse(String si_value, out Double dnum)
        {
            // si_value is expected as 999.9999 km or 999.99999 kilo-metres
            // get numerical value
            String [] string_parts = si_value.Split(' ');
            try
            {
                dnum = Double.Parse(string_parts[0]);
            }
            catch (Exception e1)
                {
                throw new Exception("Error: SI_ParseDouble failed to parse number part from " + si_value, e1);
            }

            // Parse units to get the exponent multiplier
            String[] units = string_parts[1].Split("-"); // if units is null assume short types like kg
            Double exp_adjust;
            Int32 pos;
            if (units.Length == 1) // implies short notation
            {
                // m for metres on its own no need to adjust exponent
                if (units[0].Length == 1)
                {
                    return;
                }
                // short_prefixes string is character order dependent
                String short_prefixes = "YZEPTGMk mμnpfazy";
                pos = short_prefixes.IndexOf(string_parts[1][0]);
            }
            else
            {
                // A unit has been specfied
                // Space is used to avoid a false positive where no prefix was given.
                // si_prefixes array is order dependent
                String[] si_prefixes = { "yotta", "zetta", "exa", "peta", "tera", "giga", "mega", "kilo",
                        " ", "milli", "micro", "nano", "pico", "femto", "atto", "zepto", "yocto" }; 
                pos = 0;
                // Math.Min avoids a potential argument out of range issue
                while (si_prefixes[pos] != units[0].Substring(0,Math.Min(si_prefixes[pos].Length, units[0].Length)) && pos < si_prefixes.Length) pos++; 
                if (pos == si_prefixes.Length) pos = -1;
            }
            if (pos < 0 || pos == 8)
            {
                return;
            }
            if (pos < 8)
            {
                exp_adjust = (8.0 - (Double)pos) * 3.0;
            }
            else 
            {
                exp_adjust = (((Double)pos) - 8.0) * -3.0;
            }
            Double ten = 10.0;
            dnum *= Math.Pow(ten, exp_adjust);
        }

        /// <summary>
        /// Takes an SI formatted value like "12.34 km" and returns a decimal with the
        /// value 1.234e4. A String "10pF" would be returned as a decimal value 1e-11.
        /// </summary>
        /// <param name="si_value">A string value like 12.345MHz</param>
        /// <param name="dnum">A decimal that will be assigned the parsed value from the SI formatted string</param>
        /// <returns>A decimal value adjusted for the SI prefix value.</returns>
        static public void SI_Parse(String si_value, out Decimal dnum)
        {
            // si_vale is expected as 999.9999 km or 999.99999 kilo-metres
            // get numerical value
            String[] string_parts = si_value.Split(' ');
            try
            {
                dnum = Decimal.Parse(string_parts[0]);
            }
            catch (Exception e1)
            {
                throw new Exception("Error: SI_ParseDecimal failed to parse number part from " + si_value, e1);
            }

            // Parse units to get the exponent multiplier
            String[] units = string_parts[1].Split("-"); // if units is null assume short types like kg
            Double exp_adjust;
            Int32 pos;
            if (units.Length == 1) // implies short notation
            {
                // m for metres on its own no need to adjust exponent
                if (units[0].Length == 1)
                {
                    return;
                }
                // short_prefixes string is character order dependent
                String short_prefixes = "YZEPTGMk mμnpfazy";
                pos = short_prefixes.IndexOf(string_parts[1][0]);
            }
            else
            {
                // A unit has been specfied
                // Space is used to avoid a false positive where no prefix was given.
                // si_prefixes array is order dependent
                String[] si_prefixes = { "yotta", "zetta", "exa", "peta", "tera", "giga", "mega", "kilo",
                        " ", "milli", "micro", "nano", "pico", "femto", "atto", "zepto", "yocto" };
                pos = 0;
                // Math.Min avoids a potential argument out of range issue
                while (si_prefixes[pos] != units[0].Substring(0, Math.Min(si_prefixes[pos].Length, units[0].Length)) && pos < si_prefixes.Length) pos++;
                if (pos == si_prefixes.Length) pos = -1;
            }
            if (pos < 0 || pos == 8)
            {
                return;
            }
            if (pos < 8)
            {
                exp_adjust = (8.0 - (Double)pos) * 3.0;
            }
            else
            {
                exp_adjust = (((Double)pos) - 8.0) * -3.0;
            }
            Double ten = 10.0;
            exp_adjust = Math.Pow(ten, exp_adjust);
            dnum *= (Decimal)exp_adjust;
        }

        /// <summary>
        /// Takes an SI formatted value like "12.34 km" and returns a float with the
        /// value 1.234e4. A String "10pF" would be returned as a float value 1e-11.
        /// 
        /// This function call SI_ParseDouble and converts the double to a float.
        /// </summary>
        /// <param name="si_value">A string value like 12.345MHz</param>
        /// <param name="f_num">A float that will be assigned the parsed value from the SI formatted string</param>
        /// <returns>A float value adjusted for the SI prefix value.</returns>
        static public void SI_Parse(String si_value, out float f_num)
        {
            SI_Parse(si_value, out Double d_num) ;
            f_num = (float)d_num;
        }
    }
}
