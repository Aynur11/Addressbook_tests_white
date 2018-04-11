using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.WindowsAPI;
using TestStack.White.UIItems;
using System.Windows.Automation;

namespace addressbook_tests_white
{
    public class ContactHelper : HelperBase
    {
        public string CONTACTWINTITLE = "Contact editor";

        public ContactHelper(ApplicationManager manager) : base(manager)
        {}

        public List<ContactData> GetContactsList()
        {
            List<ContactData> contacts = new List<ContactData>();
            //Panel grid = manager.MainWindow.Get(SearchCriteria.ByAutomationId("uxAddressGrid"));

            //Table grid = manager.MainWindow.Get<Table>(SearchCriteria.ByAutomationId("uxAddressGrid"));
            Table grid = (Table) manager.MainWindow.Get(SearchCriteria.ByAutomationId("uxAddressGrid"));
            
            return contacts;
        }

        private Window OpenContactsDialogue()
        {
            manager.MainWindow.Get<Button>("").Click();
            return manager.MainWindow.ModalWindow(CONTACTWINTITLE);
        }
    }
}
