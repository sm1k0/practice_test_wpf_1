using System.Windows.Controls;

namespace practice_test_wpf_1
{
    public class swappage
    {
        public static Frame stranitca { get; set; }

        public static void Swap(Page page)
        {
            if (stranitca != null)
            {
                stranitca.Content = page;
            }
        }
    }
}
