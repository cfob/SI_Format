// Maintain this file in UTF-8 coding
using System;
using System.Reflection;

namespace InfoReg
{

    /// <summary>
    /// SI_Format is a class that contains functions to adjust or parse numbers to and from
    /// strings like 10pF or 123.46 kilo-metres or 65.123 ml.
    /// </summary>
    public static class SI_Format
    {
        /// <summary>
        /// Padding is an enumberated type.
        /// An enumerated value to indicate if a dash "-" is required between the SI prefix and the unit as in kilo-gram. 
        /// Padding will also indcate if a traling space should be appended as padding.
        /// </summary>
        public enum Padding
        {
            /// <summary>
            /// dashonly: Default behaviour for Format function.
            /// </summary>
            dashonly,
            /// <summary>
            /// dashWithPadding: Use a dash but no trailing space
            /// </summary>
            dashWithPadding,
            /// <summary>
            /// paddingOnly: Add a trailing space only
            /// </summary>
            paddingOnly,
            /// <summary>
            /// noPaddingOrDash: No dash and no trailing space required
            /// </summary>
            noPaddingOrDash
        };

        /// <summary>
        /// Returns values in text in SI format. An example is 123.45km.
        /// It takes a double value and looks at its decimal exponent. The exponent 
        /// is reduced to its residue three value. It then prefixes the unit
        /// passed in with the appropriate SI prefix.
        /// 
        /// "yotta", "zetta", "exa", "peta", "tera", "giga", "mega", "kilo",
        /// "", "milli", "micro", "nano", "pico", "femto", "atto", "zepto", "yocto"
        /// 
        /// If siunit is two or less characters the return will use short SI
        /// prefixes like:
        /// "Y", "Z", "E", "P", "T", "G", "M", "k",
        /// "", "m", "μ", "n", "p", "f", "a", "z", "y"
        /// 
        /// No prefix is needed if the value of d_val lies in the range 0.0 to just under 1000.0.
        /// 
        /// Note: hecto, deca, deci, and centi are not supported.
        ///       SI does not support numbers above 10^27 or below 10^-24 
        ///       and any such value will be returned unmodified without SI prefix units.
        ///       
        /// </summary>
        /// <param name="d_val">A double value to be SI normalized.</param>
        /// <param name="sformat">Is the format string usually based on G or N </param>
        /// <param name="siunit">An SI unit like watt, metre or l</param>
        /// <param name="padding">Padding.dashOnly | Padding.dashWithPadding | Padding.paddingOnly | Padding.noPaddingOrDash</param>
        /// <returns>Formatted string e.g. "9.46 peta-metres"</returns>
        /// <example>
        ///          using InfoReg;
        ///          ...
        ///          String ans;
        ///          double val = 123.456e17;
        ///          ans = InfoReg.SI_Format.Format(val, "G6", "metres");
        ///          => ans contains: "12.3456 exa-metres"
        ///          ans = InfoReg.SI_Format.Format(val, "G6", "metres", noPaddingOrDash);
        ///          => ans contains: "12.3456 exametres"
        /// </example>
        public static String Format(double d_val, string sformat, string siunit, Padding padding = Padding.dashonly)
        {
            // Note: hecto, deca, deci, and centi are not supported
            // si does not support numbers above 10^27 or below 10^-24 
            // return unmodified without SI prefix units
            double exp;
            exp = Math.Log10(d_val);
            if (exp >= 27.0 || exp <= -24.0)
            {
                return string.Format("{0:" + sformat + "} {1}", d_val, siunit);
            }
            else
            {
                int exp1 = (int)exp / 3 * 3;
                int adjust = 8; // Array element for no SI prefix
                if (exp < 0)
                {
                    exp1 -= 3;
                }
                double dval = d_val / Math.Pow(10.0, exp1);
                int prefix_choice = -(exp1 / 3) + adjust;
                if (siunit.Length >= 3)
                {
                    string[] si_prefixes = { "yotta", "zetta", "exa", "peta", "tera", "giga", "mega", "kilo",
                        "", "milli", "micro", "nano", "pico", "femto", "atto", "zepto", "yocto" };
                    switch (padding)
                    {
                        case Padding.dashonly:
                            if (prefix_choice != 8)
                            {
                                return string.Format("{0:" + sformat + "} ", dval) + si_prefixes[prefix_choice] + "-" + siunit;
                            }
                            else
                            {
                                return string.Format("{0:" + sformat + "} ", dval) + si_prefixes[prefix_choice] + siunit;
                            }
                        case Padding.dashWithPadding:
                            if (prefix_choice != 8)
                            {
                                return string.Format("{0:" + sformat + "} ", dval) + si_prefixes[prefix_choice] + "-" + siunit + " ";
                            }
                            else
                            {
                                return string.Format("{0:" + sformat + "} ", dval) + si_prefixes[prefix_choice] + siunit + " ";
                            }
                        case Padding.paddingOnly:
                            return string.Format("{0:" + sformat + "} ", dval) + si_prefixes[prefix_choice] + siunit + " ";
                    }
                    return string.Format("{0:" + sformat + "} ", dval) + si_prefixes[prefix_choice] + siunit; // Padding.noPaddingOrDash
                }
                else
                {
                    string[] si_prefixes = { "Y", "Z", "E", "P", "T", "G", "M", "k",
                        "", "m", "μ", "n", "p", "f", "a", "z", "y" };
                    // A dash is not supported for short SI unit prefixes. Thus, supply with padding (a trailing space) or without
                    if (padding == Padding.dashWithPadding || padding == Padding.paddingOnly)
                    {
                        return string.Format("{0:" + sformat + "} ", dval) + si_prefixes[-(exp1 / 3) + adjust] + siunit + " ";
                    }
                    else
                    {
                        return string.Format("{0:" + sformat + "} ", dval) + si_prefixes[-(exp1 / 3) + adjust] + siunit;
                    }
                }
            }
        }

        /// <summary>
        /// Returns values in a text SI format. An example is 123.45km.
        /// It takes a float value and looks at its decimal exponent. The exponent 
        /// is reduced to its residue three value. It then prefixes the unit
        /// passed in with the appropriate SI prefix.
        /// 
        /// "yotta", "zetta", "exa", "peta", "tera", "giga", "mega", "kilo",
        /// "", "milli", "micro", "nano", "pico", "femto", "atto", "zepto", "yocto"
        /// 
        /// If siunit is two or less characters the return will use short SI
        /// prefixes like:
        /// "Y", "Z", "E", "P", "T", "G", "M", "k",
        /// "", "m", "μ", "n", "p", "f", "a", "z", "y"
        /// 
        /// No prefix is needed if the value of d_val lies in the range 0.0 to just under 1000.0.
        /// 
        /// Note: hecto, deca, deci, and centi are not supported.
        ///       SI does not support numbers above 10^27 or below 10^-24 
        ///       and any such value will be returned unmodified without SI prefix units.
        /// Example: ...
        ///          using InfoReg;
        ///          ...   
        ///          String ans;
        ///          float fval = (float)123.789E-7;
        ///          ans = InfoReg.SI_Format.Format(fval, "G4", "F");
        ///          => ans contains: "12.38 μF"
        ///          ans = InfoReg.SI_Format.Format(fval, "G4", "Farads", InfoReg.SI_Format.Padding.dashWithPadding);
        ///          => ans contains: "12.38 micro-Farads " // Both a dash and trailing space are used
        /// </summary>
        /// <param name="f_val">A float value to be SI normalized.</param>
        /// <param name="sformat">Is the format string usually based on G or N </param>
        /// <param name="siunit">An SI unit like watt, metre or l</param>
        /// <param name="padding">Padding.dashOnly | Padding.dashWithPadding | Padding.paddingOnly | Padding.noPaddingOrDash</param>
        /// <returns>Formatted string e.g. "9.46 peta-metres"</returns>

        public static string Format(float f_val, string sformat, string siunit, Padding padding = Padding.dashonly)
        {
            // Note: hecto, deca, deci, and centi are not supported
            // si does not support numbers above 10^27 or below 10^-24 
            // return unmodified without SI prefix units
            float exp;
            exp = System.MathF.Log10(f_val);
            if (exp >= 27.0 || exp <= -24.0)
            {
                return string.Format("{0:" + sformat + "} {1}", f_val, siunit);
            }
            else
            {
                int exp1 = (int)exp / 3 * 3;
                int adjust = 8; // Array element for no SI prefix
                if (exp < 0)
                {
                    exp1 -= 3;
                }
                float ffval = f_val / MathF.Pow(10.0f, exp1);
                int prefix_choice = -(exp1 / 3) + adjust;
                if (siunit.Length >= 3)
                {
                    string[] si_prefixes = { "yotta", "zetta", "exa", "peta", "tera", "giga", "mega", "kilo",
                        "", "milli", "micro", "nano", "pico", "femto", "atto", "zepto", "yocto" };
                    switch (padding)
                    {
                        case Padding.dashonly:
                            if (prefix_choice != 8)
                            {
                                return string.Format("{0:" + sformat + "} ", ffval) + si_prefixes[prefix_choice] + "-" + siunit;
                            }
                            else
                            {
                                return string.Format("{0:" + sformat + "} ", ffval) + si_prefixes[prefix_choice] + siunit;
                            }
                        case Padding.dashWithPadding:
                            if (prefix_choice != 8)
                            {
                                return string.Format("{0:" + sformat + "} ", ffval) + si_prefixes[prefix_choice] + "-" + siunit + " ";
                            }
                            else
                            {
                                return string.Format("{0:" + sformat + "} ", ffval) + si_prefixes[prefix_choice] + siunit + " ";
                            }
                        case Padding.paddingOnly:
                            return string.Format("{0:" + sformat + "} ", ffval) + si_prefixes[prefix_choice] + siunit + " ";
                    }
                    return string.Format("{0:" + sformat + "} ", ffval) + si_prefixes[prefix_choice] + siunit; // Padding.noPaddingOrDash
                }
                else
                {
                    string[] si_prefixes = { "Y", "Z", "E", "P", "T", "G", "M", "k",
                        "", "m", "μ", "n", "p", "f", "a", "z", "y" };
                    // A dash is not supported for short SI unit prefixes. Thus, supply with padding (a trailing space) or without
                    if (padding == Padding.dashWithPadding || padding == Padding.paddingOnly)
                    {
                        return string.Format("{0:" + sformat + "} ", ffval) + si_prefixes[-(exp1 / 3) + adjust] + siunit + " ";
                    }
                    else
                    {
                        return string.Format("{0:" + sformat + "} ", ffval) + si_prefixes[-(exp1 / 3) + adjust] + siunit;
                    }
                }
            }
        }

        /// <summary>
        /// Returns values in text in SI format. An example is 123.45km.
        /// It takes a decimal value and looks at its decimal exponent. The exponent 
        /// is reduced to its residue three value. It then prefixes the unit
        /// passed in with the appropriate SI prefix.
        /// 
        /// "yotta", "zetta", "exa", "peta", "tera", "giga", "mega", "kilo",
        /// "", "milli", "micro", "nano", "pico", "femto", "atto", "zepto", "yocto"
        /// 
        /// If siunit is two or less characters the return will use short SI
        /// prefixes like:
        /// "Y", "Z", "E", "P", "T", "G", "M", "k",
        /// "", "m", "μ", "n", "p", "f", "a", "z", "y"
        /// 
        /// No prefix is needed if the value of d_val lies in the range 0.0 to just under 1000.0.
        /// 
        /// Note: hecto, deca, deci, and centi are not supported.
        ///       SI does not support numbers above 10^27 or below 10^-24 
        ///       and any such value will be returned unmodified without SI prefix units.
        /// Example: ...
        ///          using InfoReg;
        ///          ...
        ///          String ans;
        ///          Decimal decimal_val = Decimal.Parse("1234.5678901234567890123");
        ///          ans = InfoReg.SI_Format.Format(decimal_val, "G21", "grams");
        ///          => ans contains: "1.23456789012345678901 kilo-grams"
        ///          ans = InfoReg.SI_Format.Format(decimal_val, "G21", "grams", InfoReg.SI_Format.Padding.paddingOnly);
        ///          => ans contains: "1.23456789012345678901 kilograms " // trailing space added
        /// </summary>
        /// <param name="decimal_val">A decimal value to be SI normalized.</param>
        /// <param name="sformat">Is the format string usually based on G or N </param>
        /// <param name="siunit">An SI unit like watt, metre or l</param>
        /// <param name="padding">Padding.dashOnly | Padding.dashWithPadding | Padding.paddingOnly | Padding.noPaddingOrDash</param>
        /// <returns>Formatted string e.g. "9.46 pm"</returns>


        public static string Format(decimal decimal_val, string sformat, string siunit, Padding padding = Padding.dashonly)
        {
            double exp = Math.Log10((double)decimal_val);
            if (exp >= 27.0 || exp <= -24.0)
            {
                return string.Format("{0:" + sformat + "} {1}", decimal_val, siunit);
            }
            else
            {
                int exp1 = (int)exp / 3 * 3;
                int adjust = 8;  // Array element for no SI prefix
                if (exp < 0)
                {
                    exp1 -= 3;
                }
                decimal decimal_val1 = decimal_val / (decimal)Math.Pow(10.0, exp1);
                if (siunit.Length >= 3)
                {
                    string[] si_prefixes = { "yotta", "zetta", "exa", "peta", "tera", "giga", "mega", "kilo",
                        "", "milli", "micro", "nano", "pico", "femto", "atto", "zepto", "yocto" };
                    int prefix_choice = -(exp1 / 3) + adjust;
                    switch (padding)
                    {
                        case Padding.dashonly:
                            if (prefix_choice != 8)
                            {
                                return string.Format("{0:" + sformat + "} ", decimal_val1) + si_prefixes[prefix_choice] + "-" + siunit;
                            }
                            else
                            {
                                return string.Format("{0:" + sformat + "} ", decimal_val1) + si_prefixes[prefix_choice] + siunit;
                            }
                        case Padding.dashWithPadding:
                            if (prefix_choice != 8)
                            {
                                return string.Format("{0:" + sformat + "} ", decimal_val1) + si_prefixes[prefix_choice] + "-" + siunit + " ";
                            }
                            else
                            {
                                return string.Format("{0:" + sformat + "} ", decimal_val1) + si_prefixes[prefix_choice] + siunit + " ";

                            }
                        case Padding.paddingOnly:
                            return string.Format("{0:" + sformat + "} ", decimal_val1) + si_prefixes[prefix_choice] + siunit + " ";
                    }
                    return string.Format("{0:" + sformat + "} ", decimal_val1) + si_prefixes[-(exp1 / 3) + adjust] + siunit; // Padding.noPaddingOrDash
                }
                else
                {
                    string[] si_prefixes = { "Y", "Z", "E", "P", "T", "G", "M", "k",
                        "", "m", "μ", "n", "p", "f", "a", "z", "y" };
                    return string.Format("{0:" + sformat + "} ", decimal_val1) + si_prefixes[-(exp1 / 3) + adjust] + siunit;
                }
            }
        }

        /// <summary>
        /// Takes an SI formatted value like "12.34 km" and returns a double with the
        /// value 1.234e4. A String "10pF" would be returned as a double value 1e-11.
        /// Example: ...
        ///          using InfoReg;
        ///          ...
        ///          Double val;
        ///          InfoReg.SI_Format.Parse("1.23456 km", out val);
        ///          => val has the value 1.23456e3
        ///   
        /// </summary>
        /// <param name="si_value">A string value like 12.345MHz</param>
        /// <param name="dnum">A double that will be assigned the parsed value from the SI formatted string</param>
        /// <returns>A double value adjusted for the SI prefix value.</returns>
        public static void Parse(string si_value, out double dnum)
        {
            // si_value is expected as 999.9999 km or 999.99999 kilo-metres
            // get numerical value
            string[] string_parts = si_value.Split(' ');
            try
            {
                dnum = double.Parse(string_parts[0]);
            }
            catch (Exception e1)
            {
                throw new Exception("Error: SI_ParseDouble failed to parse number part from " + si_value, e1);
            }

            // Parse units to get the exponent multiplier
            string[] units = string_parts[1].Split('-'); // if units is null assume short types like kg
            double exp_adjust;
            int pos;
            if (units.Length == 1) // implies short notation
            {
                // m for metres on its own no need to adjust exponent
                if (units[0].Length == 1)
                {
                    return;
                }
                // short_prefixes string is character order dependent
                string short_prefixes = "YZEPTGMk mμnpfazy";
                pos = short_prefixes.IndexOf(string_parts[1][0]);
            }
            else
            {
                // A unit has been specfied
                // Space is used to avoid a false positive where no prefix was given.
                // si_prefixes array is order dependent
                string[] si_prefixes = { "yotta", "zetta", "exa", "peta", "tera", "giga", "mega", "kilo",
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
                exp_adjust = (8.0 - pos) * 3.0;
            }
            else
            {
                exp_adjust = (pos - 8.0) * -3.0;
            }
            double ten = 10.0;
            dnum *= Math.Pow(ten, exp_adjust);
        }

        /// <summary>
        /// Takes an SI formatted value like "12.34 km" and returns a decimal with the
        /// value 1.234e4. A String "10pF" would be returned as a decimal value 1e-11.
        /// Example: ...
        ///          using InfoReg;
        ///          ...
        ///          Decimal val;
        ///          InfoReg.SI_Format.Parse("1.23456 km", out val);
        ///          => val has the value 1.23456e3
        /// </summary>
        /// <param name="si_value">A string value like 12.345MHz</param>
        /// <param name="dnum">A decimal that will be assigned the parsed value from the SI formatted string</param>
        /// <returns>A decimal value adjusted for the SI prefix value.</returns>
        public static void Parse(string si_value, out decimal dnum)
        {
            // si_vale is expected as 999.9999 km or 999.99999 kilo-metres
            // get numerical value
            string[] string_parts = si_value.Split(' ');
            try
            {
                dnum = decimal.Parse(string_parts[0]);
            }
            catch (Exception e1)
            {
                throw new Exception("Error: SI_ParseDecimal failed to parse number part from " + si_value, e1);
            }

            // Parse units to get the exponent multiplier
            string[] units = string_parts[1].Split('-'); // if units is null assume short types like kg
            double exp_adjust;
            int pos;
            if (units.Length == 1) // implies short notation
            {
                // m for metres on its own no need to adjust exponent
                if (units[0].Length == 1)
                {
                    return;
                }
                // short_prefixes string is character order dependent
                string short_prefixes = "YZEPTGMk mμnpfazy";
                pos = short_prefixes.IndexOf(string_parts[1][0]);
            }
            else
            {
                // A unit has been specfied
                // Space is used to avoid a false positive where no prefix was given.
                // si_prefixes array is order dependent
                string[] si_prefixes = { "yotta", "zetta", "exa", "peta", "tera", "giga", "mega", "kilo",
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
                exp_adjust = (8.0 - pos) * 3.0;
            }
            else
            {
                exp_adjust = (pos - 8.0) * -3.0;
            }
            double ten = 10.0;
            exp_adjust = Math.Pow(ten, exp_adjust);
            dnum *= (decimal)exp_adjust;
        }

        /// <summary>
        /// Takes an SI formatted value like "12.34 km" and returns a float with the
        /// value 1.234e4. A String "10pF" would be returned as a float value 1e-11.
        /// Example: ...
        ///          using InfoReg;
        ///          ...
        ///          float val;
        ///          InfoReg.SI_Format.Parse("1.23456 km", out val);
        ///          => val has the value 1.23456e3
        /// 
        /// This function calls Parse(String, out Double) and converts the double to a float.
        /// </summary>
        /// <param name="si_value">A string value like 12.345MHz</param>
        /// <param name="f_num">A float that will be assigned the parsed value from the SI formatted string</param>
        /// <returns>A float value adjusted for the SI prefix value.</returns>
        public static void Parse(string si_value, out float f_num)
        {
            Parse(si_value, out double d_num);
            f_num = (float)d_num;
        }
    }
}
