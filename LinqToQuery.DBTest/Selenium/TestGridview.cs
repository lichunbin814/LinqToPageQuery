using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class TestGridview
    {
        private static IWebDriver driver = new FirefoxDriver();
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [TestInitialize]
        public void SetupTest()
        {            
            baseURL = "http://localhost:56947/";
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [ClassCleanup]
        public static void CloseFireFox()
        {
            driver.Quit();
        }

        string[] TestAspx = new[] { @"/LinqToEntites.aspx", @"/LinqToSql.aspx" };

        [TestMethod]
        public void ��������_Gv1_�Ʀr���X()
        {
            foreach (string AspxUrl in TestAspx)
            {
                driver.Navigate().GoToUrl(baseURL + AspxUrl);                
                driver.FindElement(By.XPath("//*[@id='DataPager1_dpIndex']/a[4]")).Click();
                Assert.AreEqual("MORGK", driver.FindElement(By.XPath("//*[@id='Gv1']/tbody/tr[2]/td[1]")).Text);
                Assert.AreEqual("10", driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_TotalPagesLabel")).Text);
                Assert.AreEqual("5", driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_CurrentPageLabel")).Text);
                Assert.AreEqual("92", driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_lblRowCount")).Text);
                driver.FindElement(By.XPath("//*[@id='DataPager1_dpIndex']/a[1]")).Click();
                Assert.AreEqual("XXYYZ", driver.FindElement(By.XPath("//*[@id='Gv1']/tbody/tr[2]/td[1]")).Text);
                Assert.AreEqual("10", driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_TotalPagesLabel")).Text);
                Assert.AreEqual("1", driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_CurrentPageLabel")).Text);
                Assert.AreEqual("92", driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_lblRowCount")).Text);
                driver.FindElement(By.XPath("//*[@id='DataPager1_dpIndex']/a[9]")).Click();
                Assert.AreEqual("ANATR", driver.FindElement(By.XPath("//*[@id='Gv1']/tbody/tr[2]/td[1]")).Text);
                Assert.AreEqual("10", driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_TotalPagesLabel")).Text);
                Assert.AreEqual("10", driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_CurrentPageLabel")).Text);
                Assert.AreEqual("92", driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_lblRowCount")).Text);
            }
        }

        [TestMethod]
        public void ��������_Gv3_�Ʀr���X()
        {
            foreach (string AspxUrl in TestAspx)
            {
                driver.Navigate().GoToUrl(baseURL + AspxUrl);
                driver.FindElement(By.XPath("//*[@id='DataPager3_dpIndex']/a[3]")).Click();
                Assert.AreEqual("CONSH", driver.FindElement(By.XPath("//*[@id='Gv3']/tbody/tr[2]/td[1]")).Text);
                Assert.AreEqual("4", driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_TotalPagesLabel")).Text);
                Assert.AreEqual("4", driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_CurrentPageLabel")).Text);
                Assert.AreEqual("40", driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_lblRowCount")).Text);
                driver.FindElement(By.XPath("//*[@id='DataPager3_dpIndex']/a[2]")).Click();
                Assert.AreEqual("PICCO", driver.FindElement(By.XPath("//*[@id='Gv3']/tbody/tr[2]/td[1]")).Text);
                Assert.AreEqual("4", driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_TotalPagesLabel")).Text);
                Assert.AreEqual("2", driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_CurrentPageLabel")).Text);
                Assert.AreEqual("40", driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_lblRowCount")).Text);
                driver.FindElement(By.XPath("//*[@id='DataPager3_dpIndex']/a[1]")).Click();
                Assert.AreEqual("XXYYZ", driver.FindElement(By.XPath("//*[@id='Gv3']/tbody/tr[2]/td[1]")).Text);
                Assert.AreEqual("4", driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_TotalPagesLabel")).Text);
                Assert.AreEqual("1", driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_CurrentPageLabel")).Text);
                Assert.AreEqual("40", driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_lblRowCount")).Text);
            }
        }

        [TestMethod]
        public void ��������_Gv1_�ۭq�C������_���X�`����()
        {
            foreach (string AspxUrl in TestAspx)
            {
                driver.Navigate().GoToUrl(baseURL + AspxUrl);
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_txtPageSize")).Clear();
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_txtPageSize")).SendKeys("12");
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_txtPageSize")).SendKeys(Keys.Enter);
                Assert.AreEqual("TRADH", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[13]/td")).Text);
                Assert.AreEqual("8", driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_TotalPagesLabel")).Text);
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_txtPageSize")).Clear();
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_txtPageSize")).SendKeys("5");
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_txtPageSize")).SendKeys(Keys.Enter);
                Assert.AreEqual("WELLI", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[6]/td")).Text);
                Assert.AreEqual("19", driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_TotalPagesLabel")).Text);
            }
        }

        [TestMethod]
        public void ��������_Gv3_�ۭq�C������_���X�`����()
        {
            foreach (string AspxUrl in TestAspx)
            {
                driver.Navigate().GoToUrl(baseURL + AspxUrl);
                driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_txtPageSize")).Clear();
                driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_txtPageSize")).SendKeys("16");
                driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_txtPageSize")).SendKeys(Keys.Enter);
                Assert.AreEqual("MAISD", driver.FindElement(By.XPath("//table[@id='Gv3']/tbody/tr[14]/td")).Text);
                Assert.AreEqual("40", driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_lblRowCount")).Text);
                Assert.AreEqual("3", driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_TotalPagesLabel")).Text);
                Assert.AreEqual("1", driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_CurrentPageLabel")).Text);          
                driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_txtPageSize")).Clear();
                driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_txtPageSize")).SendKeys("5");
                driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_txtPageSize")).SendKeys(Keys.Enter);
                Assert.AreEqual("SANTG", driver.FindElement(By.XPath("//table[@id='Gv3']/tbody/tr[6]/td")).Text);
                Assert.AreEqual("40", driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_lblRowCount")).Text);
                Assert.AreEqual("8", driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_TotalPagesLabel")).Text);
                Assert.AreEqual("1", driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_CurrentPageLabel")).Text);     
            }
        }

        [TestMethod]
        public void ��������_Gv1_�ѲĤ@��_��4���U�@��_�A�I4���W�@��_��^�Ĥ@��()
        {
            foreach (string AspxUrl in TestAspx)
            {
                driver.Navigate().GoToUrl(baseURL + AspxUrl);
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_LinkButton1")).Click();
                Assert.AreEqual("WHITC", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[5]/td")).Text);
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_LinkButton3")).Click();
                Assert.AreEqual("THECR", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[6]/td")).Text);
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_LinkButton3")).Click();
                Assert.AreEqual("RICAR", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[7]/td")).Text);
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_LinkButton3")).Click();
                Assert.AreEqual("OTTIK", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[8]/td")).Text);
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_LinkButton3")).Click();
                Assert.AreEqual("LETSS", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[9]/td")).Text);
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_LinkButton2")).Click();
                Assert.AreEqual("OTTIK", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[8]/td")).Text);
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_LinkButton2")).Click();
                Assert.AreEqual("RICAR", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[7]/td")).Text);
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_LinkButton2")).Click();
                Assert.AreEqual("THECR", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[6]/td")).Text);
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_LinkButton2")).Click();
                Assert.AreEqual("WHITC", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[5]/td")).Text);
            }
        }

        [TestMethod]
        public void ��������_Gv1_�ѳ̫�@��_��4���W�@��_�A�I4���U�@��_��^�̫�@��()
        {
            foreach (string AspxUrl in TestAspx)
            {
                driver.Navigate().GoToUrl(baseURL + AspxUrl);
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_LinkButton4")).Click();
                Assert.AreEqual("ALFKI", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[3]/td")).Text);
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_LinkButton2")).Click();
                Assert.AreEqual("AROUT", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[10]/td")).Text);
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_LinkButton2")).Click();
                Assert.AreEqual("COMMI", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[9]/td")).Text);
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_LinkButton2")).Click();
                Assert.AreEqual("FRANR", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[8]/td")).Text);
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_LinkButton3")).Click();
                Assert.AreEqual("COMMI", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[9]/td")).Text);
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_LinkButton3")).Click();
                Assert.AreEqual("AROUT", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[10]/td")).Text);
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_LinkButton3")).Click();
                Assert.AreEqual("ALFKI", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[3]/td")).Text);
            }
        }


        [TestMethod]
        public void ��������_Gv2_�̫�@��_�W�@��_�Ĥ@��_�U�@��_����`��_���X_�U���\���˴�()
        {
            //Gv2�����u��2���A�ҥH�����@�_���դ����
            foreach (string AspxUrl in TestAspx)
            {
                driver.Navigate().GoToUrl(baseURL + AspxUrl);
                driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_LinkButton4")).Click();
                Assert.AreEqual("FOLKO", driver.FindElement(By.XPath("//table[@id='Gv2']/tbody/tr[6]/td")).Text);
                Assert.AreEqual("2", driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_TotalPagesLabel")).Text);
                Assert.AreEqual("2", driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_CurrentPageLabel")).Text);
                Assert.AreEqual("19", driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_lblRowCount")).Text);
                driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_LinkButton3")).Click();
                Assert.AreEqual("FOLKO", driver.FindElement(By.XPath("//table[@id='Gv2']/tbody/tr[6]/td")).Text);
                Assert.AreEqual("2", driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_TotalPagesLabel")).Text);
                Assert.AreEqual("2", driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_CurrentPageLabel")).Text);
                Assert.AreEqual("19", driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_lblRowCount")).Text);
                driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_LinkButton1")).Click();
                Assert.AreEqual("QUEEN", driver.FindElement(By.XPath("//table[@id='Gv2']/tbody/tr[8]/td")).Text);
                Assert.AreEqual("2", driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_TotalPagesLabel")).Text);
                Assert.AreEqual("1", driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_CurrentPageLabel")).Text);
                Assert.AreEqual("19", driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_lblRowCount")).Text);
                driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_LinkButton2")).Click();
                Assert.AreEqual("QUEEN", driver.FindElement(By.XPath("//table[@id='Gv2']/tbody/tr[8]/td")).Text);
                Assert.AreEqual("2", driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_TotalPagesLabel")).Text);
                Assert.AreEqual("1", driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_CurrentPageLabel")).Text);
                Assert.AreEqual("19", driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_lblRowCount")).Text);
                driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_LinkButton3")).Click();
                Assert.AreEqual("FRANK", driver.FindElement(By.XPath("//table[@id='Gv2']/tbody/tr[5]/td")).Text);
                Assert.AreEqual("2", driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_TotalPagesLabel")).Text);
                Assert.AreEqual("2", driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_CurrentPageLabel")).Text);
                Assert.AreEqual("19", driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_lblRowCount")).Text);
                driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_LinkButton2")).Click();
                Assert.AreEqual("THEBI", driver.FindElement(By.XPath("//table[@id='Gv2']/tbody/tr[5]/td")).Text);
                Assert.AreEqual("2", driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_TotalPagesLabel")).Text);
                Assert.AreEqual("1", driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_CurrentPageLabel")).Text);
                Assert.AreEqual("19", driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_lblRowCount")).Text);
            }
        }

        [TestMethod]
        public void ��������_Gv3_�Ĥ@��_�A��_�W�@��()
        {
            foreach (string AspxUrl in TestAspx)
            {
                driver.Navigate().GoToUrl(baseURL + AspxUrl);
                driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_LinkButton1")).Click();
                driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_LinkButton2")).Click();
                driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_LinkButton2")).Click();
                Assert.AreEqual("SEVES", driver.FindElement(By.XPath("//table[@id='Gv3']/tbody/tr[5]/td[1]")).Text);
            }
        }

        [TestMethod]
        public void ��������_Gv1_�Ĥ@��_�A��_�W�@��()
        {
            foreach (string AspxUrl in TestAspx)
            {
                driver.Navigate().GoToUrl(baseURL + AspxUrl);
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_LinkButton1")).Click();
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_LinkButton2")).Click();
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_LinkButton2")).Click();
                Assert.AreEqual("WHITC", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[5]/td")).Text);
            }
        }

        [TestMethod]
        public void ��������_Gv1_�̫�@��_�A��_�U�@��()
        {
            foreach (string AspxUrl in TestAspx)
            {
                driver.Navigate().GoToUrl(baseURL + AspxUrl);
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_LinkButton4")).Click();
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_LinkButton3")).Click();
                driver.FindElement(By.Id("DataPager1_dpIndex_ctl01_LinkButton3")).Click();
                Assert.AreEqual("ALFKI", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[3]/td")).Text);
            }
        }

        [TestMethod]
        public void ��������_Gv3_�̫�@��_�A��_�U�@��()
        {
            foreach (string AspxUrl in TestAspx)
            {
                driver.Navigate().GoToUrl(baseURL + AspxUrl);
                driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_LinkButton4")).Click();
                driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_LinkButton3")).Click();
                driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_LinkButton3")).Click();
                Assert.AreEqual("CHOPS", driver.FindElement(By.XPath("//table[@id='Gv3']/tbody/tr[3]/td")).Text);
            }
        }

        [TestMethod]
        public void ��������_Gv1_�Ƨ�()
        {
            foreach (string AspxUrl in TestAspx)
            {
                driver.Navigate().GoToUrl(baseURL + AspxUrl);
                driver.FindElement(By.XPath("//*[@id='Gv1']/tbody/tr[1]/th[2]/a")).Click();
                Assert.AreEqual("�}��l", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[2]/td[3]")).Text);
                driver.FindElement(By.XPath("//*[@id='Gv1']/tbody/tr[1]/th[2]/a")).Click();
                Assert.AreEqual("��p�j", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[2]/td[3]")).Text);
            }
        }

        [TestMethod]
        public void ��������_Gv2_�Ƨ�()
        {
            foreach (string AspxUrl in TestAspx)
            {
                driver.Navigate().GoToUrl(baseURL + AspxUrl);
                driver.FindElement(By.XPath("//*[@id='Gv2']/tbody/tr[1]/th[1]/a")).Click();
                Assert.AreEqual("�x�_�������F���|�q32��", driver.FindElement(By.XPath("//table[@id='Gv2']/tbody/tr[2]/td[3]")).Text);
                driver.FindElement(By.XPath("//*[@id='Gv2']/tbody/tr[1]/th[1]/a")).Click();
                Assert.AreEqual("�x�_�����v�F���T�q15���Q��", driver.FindElement(By.XPath("//table[@id='Gv2']/tbody/tr[2]/td[3]")).Text);
            }
        }

        [TestMethod]
        public void ��������_Gv3_�Ƨ�()
        {
            foreach (string AspxUrl in TestAspx)
            {
                driver.Navigate().GoToUrl(baseURL + AspxUrl);
                driver.FindElement(By.XPath("//*[@id='Gv3']/tbody/tr[1]/th[2]/a")).Click();
                Assert.AreEqual("BSBEV", driver.FindElement(By.XPath("//table[@id='Gv3']/tbody/tr[2]/td[1]")).Text);
                driver.FindElement(By.XPath("//*[@id='Gv3']/tbody/tr[1]/th[2]/a")).Click();
                Assert.AreEqual("BOTTM", driver.FindElement(By.XPath("//table[@id='Gv3']/tbody/tr[2]/td[1]")).Text);
            }
        }

        [TestMethod]
        public void ��������_Gv2_���o�z��᪺���()
        {
            foreach (string AspxUrl in TestAspx)
            {
                driver.Navigate().GoToUrl(baseURL + AspxUrl);
                #region �T�w���W��
                Assert.AreEqual("CustomerID", driver.FindElement(By.XPath("//table[@id='Gv2']/tbody/tr/th[1]")).Text);
                Assert.AreEqual("City", driver.FindElement(By.XPath("//table[@id='Gv2']/tbody/tr/th[2]")).Text);
                Assert.AreEqual("Address", driver.FindElement(By.XPath("//table[@id='Gv2']/tbody/tr/th[3]")).Text);
                #endregion
                #region �T�w��줺�e
                Assert.AreEqual("VICTE", driver.FindElement(By.XPath("//table[@id='Gv2']/tbody/tr[4]/td")).Text);
                Assert.AreEqual("�x�_��", driver.FindElement(By.XPath("//table[@id='Gv2']/tbody/tr[5]/td[2]")).Text);
                Assert.AreEqual("�x�_�������F���|�q32��", driver.FindElement(By.XPath("//table[@id='Gv2']/tbody/tr[5]/td[3]")).Text);
                #endregion

                //�T�w�`����
                Assert.AreEqual("19", driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_lblRowCount")).Text);
            }
        }

        [TestMethod]
        public void ��������_���oPostalCode_10000��50500�����()
        {
            foreach (string AspxUrl in TestAspx)
            {
                driver.Navigate().GoToUrl(baseURL + AspxUrl);
                #region �T�w������
                Assert.AreEqual("CustomerID", driver.FindElement(By.XPath("//table[@id='Gv3']/tbody/tr/th[1]")).Text);
                Assert.AreEqual("Address", driver.FindElement(By.XPath("//table[@id='Gv3']/tbody/tr/th[2]")).Text);
                #endregion
                #region �T�w��Ƥ��e
                Assert.AreEqual("SEVES", driver.FindElement(By.XPath("//table[@id='Gv3']/tbody/tr[5]/td")).Text);
                Assert.AreEqual("�s�˥��å����@�q1��", driver.FindElement(By.XPath("//table[@id='Gv3']/tbody/tr[8]/td[2]")).Text);
                #endregion
                Assert.AreEqual("40", driver.FindElement(By.Id("DataPager3_dpIndex_ctl01_lblRowCount")).Text);
            }
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
