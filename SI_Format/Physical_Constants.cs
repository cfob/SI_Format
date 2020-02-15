// Maintain this file in UTF-8 coding

namespace InfoReg
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
        public const double LightSpeed = 299792458.0; // m/s
        /// <summary>
        /// GravitationalConstant is the gravitational constant
        /// </summary>
        public const double GravitationalConstant = 6.67430e-11; // cubic-metres/(kilo-gram (second squared))
        /// <summary>
        /// PlanckConstant is Plank's constant
        /// </summary>
        public const double PlanckConstant = 6.62607015e-34; // J / s
        /// <summary>
        /// ReducedPlankConstant is the reduced Plank's constant
        /// </summary>
        public const double ReducedPlankConstant = 1.0545718e-34; // J / Hz
        /// <summary>
        /// MagneticConstant is the magnetic constant
        /// </summary>
        public const double MagneticConstant = 1.25663706212e-6; // Neutons/sqaure Amp
        /// <summary>
        /// ElectricConstant is the electric constant
        /// </summary>
        public const double ElectricConstant = 8.8541878128e-12; // Farads/metre
                                                                 // Electromagnetic constant
        /// <summary>
        /// MagneticFluxQuantum is the quantum magnetic flux constant
        /// </summary>
        public const double MagneticFluxQuantum = 2.067833831e-15; // Wb
        /// <summary>
        /// ElementaryCharge is the elementary charge constant
        /// </summary>
        public const double ElementaryCharge = 1.602176634e-19; // C
        /// <summary>
        /// ElementaryCharge is the quantum conductance constant
        /// </summary>
        public const double ConductanceQuantum = 7.748091729e-5; // S
                                                                 // Atomic and nuclear
        /// <summary>
        /// ElectronMass is the mass of an electron
        /// </summary>
        public const double ElectronMass = 9.1093837015e-31; // kg
        /// <summary>
        /// ProtonMass is the mass of a proton
        /// </summary>
        public const double ProtonMass = 1.67262192369e-27; // kg
        /// <summary>
        /// FineStructureConstant is the fine structure constant
        /// </summary>
        public const double FineStructureConstant = 7.2973525693e-3;
        /// <summary>
        /// RydbergConstant is the Rydberg constant
        /// </summary>
        public const double RydbergConstant = 10973731.568160; // per metre
        /// <summary>
        /// BohrRadius is the Bohr radius constant
        /// </summary>
        public const double BohrRadius = 5.29177210903e-11; // m
        /// <summary>
        /// ClassicalElectronRadius is the classical electron radius constant
        /// </summary>
        public const double ClassicalElectronRadius = 2.8179403262e-15; // m
                                                                        // Physio-chemical constants
        /// <summary>
        /// AtomicMassUnit is the atomic mass unit constant
        /// </summary>
        public const double AtomicMassUnit = 1.66053906660e-27; // kg
        /// <summary>
        /// AvogadroConstant is the Avogadro constant
        /// </summary>
        public const double AvogadroConstant = 6.02214076e-23; // per mol
        /// <summary>
        /// FaradayConstant is the Faraday constant
        /// </summary>
        public const double FaradayConstant = 96485.33212; // C/mol
        /// <summary>
        /// MolarGasConstant is the Molar Gas Constant
        /// </summary>
        public const double MolarGasConstant = 8.314462618; // J/(mol K)
        /// <summary>
        /// BoltzmannConstant is the Boltzmann's constant
        /// </summary>
        public const double BoltzmannConstant = 1.380649 - 23; // J/K
        /// <summary>
        /// Stefan_BoltzmannConstant is the Stefan_Boltzmann's constant
        /// </summary>
        public const double Stefan_BoltzmannConstant = 5.670374419e-8; // W m^-2 K^-4
                                                                       // Other commonly us
        /// <summary>
        /// ElectronVolt is an electron volt
        /// </summary>
        public const double ElectronVolt = 1.602176634e-19; // J
        /// <summary>
        /// StandardGravity rate of accelleration due to gravity on Earth
        /// </summary>
        public const double StandardGravity = 9.80665; // m/s/s
        /// <summary>
        /// Pi is the value of the pi constant i.e. numer of radii to make a semi circle based on that radius
        /// </summary>
        public const double Pi = 3.14159265359;
        /// <summary>
        /// NaturalLogBase the base used for natural logs
        /// </summary>
        public const double NaturalLogBase = 2.71828182846;
    }
}
