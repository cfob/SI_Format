// Maintain this file in UTF-8
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using InfoReg;

namespace InfoRegSI
{
    [TestClass]
    public class SI_Format_Test
    {
        [TestMethod]
        public void SI_Double()
        {
            string AssertErrorMsg = "InfoReg.SI_Format.Format(Double, String) failed.";
            string ans;
            double val = 123.456e17;
            ans = InfoReg.SI_Format.Format(val, "G6", "metres");
            Assert.AreEqual("12.3456 exa-metres", ans, false, AssertErrorMsg);
            ans = InfoReg.SI_Format.Format(val, "G6", "m");
            Assert.AreEqual("12.3456 Em", ans, false, AssertErrorMsg);
            val = 98.7654E-21;
            ans = InfoReg.SI_Format.Format(val, "G6", "g");
            Assert.AreEqual("98.7654 zg", ans, false, AssertErrorMsg);
            val = 99.9995E32;
            ans = InfoReg.SI_Format.Format(val, "G7", "litres");
            Assert.AreEqual("9.99995E+33 litres", ans, false, AssertErrorMsg);
            val = 99.9994E-29;
            ans = InfoReg.SI_Format.Format(val, "G7", "litres");
            Assert.AreEqual("9.99994E-28 litres", ans, false, AssertErrorMsg);
            val = 45.7;
            ans = InfoReg.SI_Format.Format(val, "G7", "m");
            Assert.AreEqual("45.7 m", ans, false, AssertErrorMsg);
            // "G4" will only print 3 characters in next test
            val = 0.5;
            ans = InfoReg.SI_Format.Format(val, "G4", "l");
            Assert.AreEqual("500 ml", ans, false, AssertErrorMsg);
            val = 1500;
            ans = InfoReg.SI_Format.Format(val, "N2", "m");
            Assert.AreEqual("1.50 km", ans, false, AssertErrorMsg);
            // A light year (based on an average 365.25 Earth days) in a vacuum
            val = 365.25 * 24.0 * 60.0 * 60.0 * InfoReg.Physical_Constants.LightSpeed;
            ans = InfoReg.SI_Format.Format(val, "G3", "metres");
            Assert.AreEqual("9.46 peta-metres", ans, false, AssertErrorMsg);
        }

        [TestMethod]
        public void SI_Float()
        {
            string AssertErrorMsg = "InfoReg.SI_Format.Format(float, String) failed.";
            string ans;
            float fval = (float)123.789E-7;
            ans = InfoReg.SI_Format.Format(fval, "G4", "F");
            Assert.AreEqual("12.38 μF", ans, false, AssertErrorMsg);
        }

        [TestMethod]
        public void SI_Decimal()
        {
            string ans;
            string AssertErrorMsg = "InfoReg.SI_Format.Format(Decimal, String) failed.";
            decimal decimal_val = decimal.Parse("1234.5678901234567890123");
            ans = InfoReg.SI_Format.Format(decimal_val, "G21", "grams");
            Assert.AreEqual("1.23456789012345678901 kilo-grams", ans, false, AssertErrorMsg);

        }

        [TestMethod]
        public void SI_ParseDouble()
        {
            double val;
            string AssertErrorMsg = "Double InfoReg.SI_Format.Parse failed.";
            InfoReg.SI_Format.Parse("1.23456 km", out val);
            double dans = 1.23456e3;
            Assert.AreEqual(dans, val, 1.0e-6, AssertErrorMsg);
            InfoReg.SI_Format.Parse("1.23456 mega-litres", out val);
            dans = 1.23456e6;
            Assert.AreEqual(dans, val, 1.0e-3, AssertErrorMsg);
            InfoReg.SI_Format.Parse("1.23456 pico-farad", out val);
            dans = 1.23456e-12;
            Assert.AreEqual(dans, val, 1.0e-18, AssertErrorMsg);
            InfoReg.SI_Format.Parse("1.23456 ns", out val);
            dans = 1.23456e-9;
            Assert.AreEqual(dans, val, 1.0e-15, AssertErrorMsg);
            InfoReg.SI_Format.Parse("1.23456 m", out val);
            dans = 1.23456;
            Assert.AreEqual(dans, val, 1.0e-6, AssertErrorMsg);
            InfoReg.SI_Format.Parse("1.23456 kilometres", out val);
            dans = 1.23456e3;
            Assert.AreEqual(dans, val, 1.0e-6, AssertErrorMsg);
        }

        [TestMethod]
        public void SI_ParseFloat()
        {
            float val;
            string AssertErrorMsg = "InfoReg.SI_Format.ParseFloat failed.";
            InfoReg.SI_Format.Parse("1.23456 km", out val);
            double dans = 1.23456e3;
            Assert.AreEqual(dans, val, 1.0e-4, AssertErrorMsg);
            InfoReg.SI_Format.Parse("1.23456 mega-litres", out val);
            dans = 1.23456e6;
            Assert.AreEqual(dans, val, 1.0e-3, AssertErrorMsg);
            InfoReg.SI_Format.Parse("1.23456 pico-farad", out val);
            dans = 1.23456e-12;
            Assert.AreEqual(dans, val, 1.0e-18, AssertErrorMsg);
            InfoReg.SI_Format.Parse("1.23456 ns", out val);
            dans = 1.23456e-9;
            Assert.AreEqual(dans, val, 1.0e-15, AssertErrorMsg);
            InfoReg.SI_Format.Parse("1.23456 m", out val);
            dans = 1.23456;
            Assert.AreEqual(dans, val, 1.0e-6, AssertErrorMsg);
            InfoReg.SI_Format.Parse("1.23456 kilometres", out val);
            dans = 1.23456e3;
            Assert.AreEqual(dans, val, 1.0e-4, AssertErrorMsg);
        }

        [TestMethod]
        public void SI_ParseDecimal()
        {
            decimal val;
            string AssertErrorMsg = "InfoReg.SI_Format.ParseDecimal failed.";
            InfoReg.SI_Format.Parse("1.234567890123456789012 km", out val);
            decimal dans = (decimal)1234.567890123456789012;
            Assert.AreEqual(dans.ToString("N"), val.ToString("N"), true, AssertErrorMsg);
            InfoReg.SI_Format.Parse("1.234567890123456789012 mega-litres", out val);
            dans = (decimal)1234567.890123456789012;
            Assert.AreEqual(dans.ToString("N"), val.ToString("N"), true, AssertErrorMsg);
            InfoReg.SI_Format.Parse("1.234567890123456789012 pico-farad", out val);
            dans = (decimal)0.00000000000123456789012;
            Assert.AreEqual(dans.ToString("N1.16"), val.ToString("N1.16"), true, AssertErrorMsg);
        }
    }
}

