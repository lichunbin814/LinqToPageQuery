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
        public void 網頁測試_Gv1_數字頁碼()
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
        public void 網頁測試_Gv3_數字頁碼()
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
        public void 網頁測試_Gv1_自訂每頁筆數_頁碼總筆數()
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
        public void 網頁測試_Gv3_自訂每頁筆數_頁碼總筆數()
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
        public void 網頁測試_Gv1_由第一頁_按4次下一頁_再點4次上一頁_返回第一頁()
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
        public void 網頁測試_Gv1_由最後一頁_按4次上一頁_再點4次下一頁_返回最後一頁()
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
        public void 網頁測試_Gv2_最後一頁_上一頁_第一頁_下一頁_資料總數_頁碼_各項功能檢測()
        {
            //Gv2分頁只有2頁，所以全部一起測試比較快
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
        public void 網頁測試_Gv3_第一頁_再按_上一頁()
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
        public void 網頁測試_Gv1_第一頁_再按_上一頁()
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
        public void 網頁測試_Gv1_最後一頁_再按_下一頁()
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
        public void 網頁測試_Gv3_最後一頁_再按_下一頁()
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
        public void 網頁測試_Gv1_排序()
        {
            foreach (string AspxUrl in TestAspx)
            {
                driver.Navigate().GoToUrl(baseURL + AspxUrl);
                driver.FindElement(By.XPath("//*[@id='Gv1']/tbody/tr[1]/th[2]/a")).Click();
                Assert.AreEqual("徐文彬", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[2]/td[3]")).Text);
                driver.FindElement(By.XPath("//*[@id='Gv1']/tbody/tr[1]/th[2]/a")).Click();
                Assert.AreEqual("鍾小姐", driver.FindElement(By.XPath("//table[@id='Gv1']/tbody/tr[2]/td[3]")).Text);
            }
        }

        [TestMethod]
        public void 網頁測試_Gv2_排序()
        {
            foreach (string AspxUrl in TestAspx)
            {
                driver.Navigate().GoToUrl(baseURL + AspxUrl);
                driver.FindElement(By.XPath("//*[@id='Gv2']/tbody/tr[1]/th[1]/a")).Click();
                Assert.AreEqual("台北市忠孝東路四段32號", driver.FindElement(By.XPath("//table[@id='Gv2']/tbody/tr[2]/td[3]")).Text);
                driver.FindElement(By.XPath("//*[@id='Gv2']/tbody/tr[1]/th[1]/a")).Click();
                Assert.AreEqual("台北市民權東路三段15號十樓", driver.FindElement(By.XPath("//table[@id='Gv2']/tbody/tr[2]/td[3]")).Text);
            }
        }

        [TestMethod]
        public void 網頁測試_Gv3_排序()
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
        public void 網頁測試_Gv2_取得篩選後的資料()
        {
            foreach (string AspxUrl in TestAspx)
            {
                driver.Navigate().GoToUrl(baseURL + AspxUrl);
                #region 確定欄位名稱
                Assert.AreEqual("CustomerID", driver.FindElement(By.XPath("//table[@id='Gv2']/tbody/tr/th[1]")).Text);
                Assert.AreEqual("City", driver.FindElement(By.XPath("//table[@id='Gv2']/tbody/tr/th[2]")).Text);
                Assert.AreEqual("Address", driver.FindElement(By.XPath("//table[@id='Gv2']/tbody/tr/th[3]")).Text);
                #endregion
                #region 確定欄位內容
                Assert.AreEqual("VICTE", driver.FindElement(By.XPath("//table[@id='Gv2']/tbody/tr[4]/td")).Text);
                Assert.AreEqual("台北市", driver.FindElement(By.XPath("//table[@id='Gv2']/tbody/tr[5]/td[2]")).Text);
                Assert.AreEqual("台北市忠孝東路四段32號", driver.FindElement(By.XPath("//table[@id='Gv2']/tbody/tr[5]/td[3]")).Text);
                #endregion

                //確定總筆數
                Assert.AreEqual("19", driver.FindElement(By.Id("DataPager2_dpIndex_ctl01_lblRowCount")).Text);
            }
        }

        [TestMethod]
        public void 網頁測試_取得PostalCode_10000到50500的資料()
        {
            foreach (string AspxUrl in TestAspx)
            {
                driver.Navigate().GoToUrl(baseURL + AspxUrl);
                #region 確定資料欄位
                Assert.AreEqual("CustomerID", driver.FindElement(By.XPath("//table[@id='Gv3']/tbody/tr/th[1]")).Text);
                Assert.AreEqual("Address", driver.FindElement(By.XPath("//table[@id='Gv3']/tbody/tr/th[2]")).Text);
                #endregion
                #region 確定資料內容
                Assert.AreEqual("SEVES", driver.FindElement(By.XPath("//table[@id='Gv3']/tbody/tr[5]/td")).Text);
                Assert.AreEqual("新竹市永平路一段1號", driver.FindElement(By.XPath("//table[@id='Gv3']/tbody/tr[8]/td[2]")).Text);
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
