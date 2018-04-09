using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_white
{
    public class TestBase
    {
        public ApplicationManager app;

        [SetUpFixture]
        public void InitApplication()
        {
            app
            app = new ApplicationManager();
        }

        [OneTimeTearDown]
        public void StopApplication()
        {
            app.Stop();
        }
    }
}
