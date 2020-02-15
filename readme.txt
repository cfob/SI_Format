// SI Description
// SI.Physical_Constants
//
// Date 20191204
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
        public const Double LightSpeed = 299792458.0; // m/s
        public const Double GravitationalConstant = 6.67430e-11; // cubic-metres/(kilo-gram (second squared))
        public const Double PlanckConstant = 6.62607015e-34; // J / s
        public const Double ReducedPlankConstant = 1.0545718e-34; // J / Hz
        public const Double MagneticConstant = 1.25663706212e-6; // Neutons/sqaure Amp
        public const Double ElectricConstant = 8.8541878128e-12; // Farads/metre
// Electromagnetic constants
        public const Double MagneticFluxQuantum = 2.067833831e-15; // Wb
        public const Double ElementaryCharge = 1.602176634e-19; // C
        public const Double ConductanceQuantum = 7.748091729e-5; // S
// Atomic and nuclear
        public const Double ElectronMass = 9.1093837015e-31; // kg
        public const Double ProtonMass = 1.67262192369e-27; // kg
        public const Double FineStructureConstant = 7.2973525693e-3; 
        public const Double RydbergConstant = 10973731.568160; // per metre
        public const Double BohrRadius = 5.29177210903e-11; // m
        public const Double ClassicalElectronRadius = 2.8179403262e-15; // m
// Physio-chemical constants
        public const Double AtomicMassUnit = 1.66053906660e-27; // kg
        public const Double AvogadroConstant = 6.02214076e-23; // per mol
        public const Double FaradayConstant = 96485.33212; // C/mol
        public const Double MolarGasConstant = 8.314462618; // J/(mol K)
        public const Double BoltzmannConstant = 1.380649-23; // J/K
        public const Double Stefan_BoltzmannConstant = 5.670374419e-8; // W m^-2 K^-4
 // Other commonly used
        public const Double ElectronVolt = 1.602176634e-19; // J
        public const Double StandardGravity = 9.80665; // m/s/s
        public const Double Pi = 3.14159265359;
        public const Double NaturalLogBase = 2.71828182846;

// InfoReg.SI_Format.Format

       String Format(Double dval, String sformat, String unit)
       sformat can be in G or N formats please see:
       https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#the-general-g-format-specifier
       or
       https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#the-numeric-n-format-specifier
       
    // Examples as used in the unit test

            double val = 123.456e17;
            ans = InfoReg.SI_Format.Format(val, "G6", "metres");
            ans contains "12.3456 exa-metres"
            
            ans = InfoReg.SI_Format.Format(val, "G6", "m");
            ans contains "12.3456 Em". This making use of the short prefix because the unit was expressed in short form.

            val = 98.7654E-21;
            ans = InfoReg.SI_Format.Format(val, "G6", "g");
            ans contains "98.7654 zg"

            val = 99.9995E32;
            ans = InfoReg.SI_Format.Format(val, "G7", "litres");
            ans contains "9.99995E+33 litres". This value is too high for SI prefixes.

            val = 99.9994E-29;
            ans = InfoReg.SI_Format.Format(val, "G7", "litres");
            ans contains "9.99994E-28 litres". This value is too small for SI prefixes.

            val = 45.7;
            ans = InfoReg.SI_Format.Format(val, "G7", "m");
            ans contains "45.7 m". No SI prefix provided in the 0 999.999999... range.

            // "G4" will only print 3 characters in next test
            val = 0.5;
            ans = InfoReg.SI_Format.Format(val, "G4", "l");
            ans contains "500 ml".

            val = 1500;
            ans = InfoReg.SI_Format.Format(val, "N2", "m");
            ans contains "1.50 km".

            val = 365.25 * 24.0 * 60.0 * 60.0 * SI.Physical_Constants.LightSpeed;
            ans = InfoReg.SI_Format.Format(val, "G3", "metres");
            ans contains "9.46 peta-metres". This distance is also known as a light-year.
            
// String InfoReg.SI_Format.Format(Float fval, String sformat, String unit)
       sformat can be in G or N formats please see:
       https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#the-general-g-format-specifier
       or
       https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#the-numeric-n-format-specifier

            float fval = (float)123.789E-7;
            ans = InfoReg.SI_Format.Format(fval, "G4", "F");
            ans contains "12.38 μF". Save in UTF-8 to preserve the greek character "μ".

// String InfoReg.SI_Format.Format(Decimal decimal_val, String sformat, String unit)
       sformat can be in G or N formats please see:
       https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#the-general-g-format-specifier
       or
       https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#the-numeric-n-format-specifier

            Decimal decimal_val = Decimal.Parse("1234.5678901234567890123");
            ans = InfoReg.SI_Format.Format(decimal_val, "G21", "grams");
            ans contains "1.23456789012345678901 kilo-grams".

//  void InfoReg.SI_Format.Parse(String, out Double)
            double dans;
            InfoReg.SI_Format.Parse("1.23456 km", out dans);
            => dans now has a value of 1.23456e3

// void InfoReg.SI_Format.Parse(String, out float)
            float val;
            InfoReg.SI_Format.Parse("1.23456 km", out val);
            => the value of val is 1.23456e3;

// void InfoReg.SI_Format.Parse(String, out Decimal)
            decimal val;
            InfoReg.SI_Format.Parse("1.234567890123456789012 km", out val);
            => val has a value of (decimal)1234.567890123456789012;
