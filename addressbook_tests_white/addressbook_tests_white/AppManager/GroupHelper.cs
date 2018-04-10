using System;
using System.Collections.Generic;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.WindowsAPI;
using TestStack.White.UIItems;
using System.Windows.Automation;

namespace addressbook_tests_white
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";

       
        public GroupHelper(ApplicationManager manager) : base(manager) { }



        public List<GroupData> GetGroupsList()
        {
            List<GroupData> list = new List<GroupData>();

            Window dialogue = OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach(TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });
            }
            CloseGroupsDialogue(dialogue);
            return list;
        }

        public void Add(GroupData newGroup)
        {
            Window dialogue = OpenGroupsDialogue();
            dialogue.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox) dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupsDialogue(dialogue);
        }

        public void Remove(GroupData toBeRemoved)
        {
            Window dialogue = OpenGroupsDialogue();
            dialogue.Get<TreeNode>(SearchCriteria.ByText(toBeRemoved.Name)).Click();
            dialogue.Get<Button>("uxDeleteAddressButton").Click();
            Window deleteDialogue = dialogue.ModalWindow("Delete group");
            deleteDialogue.Get<Button>("uxOKAddressButton").Click();
            CloseGroupsDialogue(dialogue);
        }
        private Window OpenGroupsDialogue()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);

        }

        private void CloseGroupsDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();
        }
    }
}