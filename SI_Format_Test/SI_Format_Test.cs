// Maintain this file in UTF-8 coding
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InfoReg_SI;

namespace InfoReg_SI
{
    [TestClass]
    public class SI_Format_Test
    {
        [TestMethod]
        public void SI_Double()
        {
            String AssertErrorMsg = "InfoReg_SI.Format.SI_Format(Double, String) failed.";
            String ans;
            double val = 123.456e17;
            ans = InfoReg_SI.Format.SI_Format(val, "G6", "metres");
            Assert.AreEqual("12.3456 exa-metres", ans, false, AssertErrorMsg);
            ans = InfoReg_SI.Format.SI_Format(val, "G6", "m");
            Assert.AreEqual("12.3456 Em", ans, false, AssertErrorMsg);
            val = 98.7654E-21;
            ans = InfoReg_SI.Format.SI_Format(val, "G6", "g");
            Assert.AreEqual("98.7654 zg", ans, false, AssertErrorMsg);
            val = 99.9995E32;
            ans = InfoReg_SI.Format.SI_Format(val, "G7", "litres");
            Assert.AreEqual("9.99995E+33 litres", ans, false, AssertErrorMsg);
            val = 99.9994E-29;
            ans = InfoReg_SI.Format.SI_Format(val, "G7", "litres");
            Assert.AreEqual("9.99994E-28 litres", ans, false, AssertErrorMsg);
            val = 45.7;
            ans = InfoReg_SI.Format.SI_Format(val, "G7", "m");
            Assert.AreEqual("45.7 m", ans, false, AssertErrorMsg);
            // "G4" will only print 3 characters in next test
            val = 0.5;
            ans = InfoReg_SI.Format.SI_Format(val, "G4", "l");
            Assert.AreEqual("500 ml", ans, false, AssertErrorMsg);
            val = 1500;
            ans = InfoReg_SI.Format.SI_Format(val, "N2", "m");
            Assert.AreEqual("1.50 km", ans, false, AssertErrorMsg);
            // A light year (based on an average 365.25 Earth days) in a vacuum
            val = 365.25 * 24.0 * 60.0 * 60.0 * InfoReg_SI.Physical_Constants.LightSpeed;
            ans = InfoReg_SI.Format.SI_Format(val, "G3", "metres");
            Assert.AreEqual("9.46 peta-metres", ans, false, AssertErrorMsg);
        }

        [TestMethod]
        public void SI_Float()
        {
            String AssertErrorMsg = "InfoReg_SI.Format.SI_Format(float, String) failed.";
            String ans;

            float fval = (float)123.789E-7;
            ans = InfoReg_SI.Format.SI_Format(fval, "G4", "F");
            Assert.AreEqual("12.38 μF", ans, false, AssertErrorMsg);
        }

        [TestMethod]
        public void SI_Decimal()
        {
            String ans;
            String AssertErrorMsg = "InfoReg_SI.Format.SI_Format(Decimal, String) failed.";
            Decimal decimal_val = Decimal.Parse("1234.5678901234567890123");
            ans = InfoReg_SI.Format.SI_Format(decimal_val, "G21", "grams");
            Assert.AreEqual("1.23456789012345678901 kilo-grams", ans, false, AssertErrorMsg);

        }

        [TestMethod]
        public void SI_ParseDouble()
        {
            Double val;
            String AssertErrorMsg = "Double InfoReg_SI.Format.SI_Parse failed.";
            InfoReg_SI.Format.SI_Parse("1.23456 km", out val);
            Double dans = 1.23456e3;
            Assert.AreEqual(dans, val, 1.0e-6, AssertErrorMsg);
            InfoReg_SI.Format.SI_Parse("1.23456 mega-litres", out val);
            dans = 1.23456e6;
            Assert.AreEqual(dans, val, 1.0e-3, AssertErrorMsg);
            InfoReg_SI.Format.SI_Parse("1.23456 pico-farad", out val);
            dans = 1.23456e-12;
            Assert.AreEqual(dans, val, 1.0e-18, AssertErrorMsg);
            InfoReg_SI.Format.SI_Parse("1.23456 ns", out val);
            dans = 1.23456e-9;
            Assert.AreEqual(dans, val, 1.0e-15, AssertErrorMsg);
            InfoReg_SI.Format.SI_Parse("1.23456 m", out val);
            dans = 1.23456;
            Assert.AreEqual(dans, val, 1.0e-6, AssertErrorMsg);
            InfoReg_SI.Format.SI_Parse("1.23456 kilometres", out val);
            dans = 1.23456e3;
            Assert.AreEqual(dans, val, 1.0e-6, AssertErrorMsg);
        }

        [TestMethod]
        public void SI_ParseFloat()
        {
            float val;
            String AssertErrorMsg = "InfoReg_SI.Format.SI_ParseFloat failed.";
            InfoReg_SI.Format.SI_Parse("1.23456 km", out val);
            Double dans = 1.23456e3;
            Assert.AreEqual(dans, val, 1.0e-4, AssertErrorMsg);
            InfoReg_SI.Format.SI_Parse("1.23456 mega-litres", out val);
            dans = 1.23456e6;
            Assert.AreEqual(dans, val, 1.0e-3, AssertErrorMsg);
            InfoReg_SI.Format.SI_Parse("1.23456 pico-farad", out val);
            dans = 1.23456e-12;
            Assert.AreEqual(dans, val, 1.0e-18, AssertErrorMsg);
            InfoReg_SI.Format.SI_Parse("1.23456 ns", out val);
            dans = 1.23456e-9;
            Assert.AreEqual(dans, val, 1.0e-15, AssertErrorMsg);
            InfoReg_SI.Format.SI_Parse("1.23456 m", out val);
            dans = 1.23456;
            Assert.AreEqual(dans, val, 1.0e-6, AssertErrorMsg);
            InfoReg_SI.Format.SI_Parse("1.23456 kilometres", out val);
            dans = 1.23456e3;
            Assert.AreEqual(dans, val, 1.0e-4, AssertErrorMsg);
        }

        [TestMethod]
        public void SI_ParseDecimal()
        {
            Decimal val;
            String AssertErrorMsg = "InfoReg_SI.Format.SI_ParseDecimal failed.";
            InfoReg_SI.Format.SI_Parse("1.234567890123456789012 km", out val);
            Decimal dans = (Decimal)1234.567890123456789012;
            Assert.AreEqual(dans.ToString("N"), val.ToString("N"), true, AssertErrorMsg);
            InfoReg_SI.Format.SI_Parse("1.234567890123456789012 mega-litres", out val);
            dans = (Decimal)1234567.890123456789012;
            Assert.AreEqual(dans.ToString("N"), val.ToString("N"), true, AssertErrorMsg);
            InfoReg_SI.Format.SI_Parse("1.234567890123456789012 pico-farad", out val);
            dans = (Decimal)0.00000000000123456789012;
            Assert.AreEqual(dans.ToString("N1.16"), val.ToString("N1.16"), true, AssertErrorMsg);
        }
    }
}
