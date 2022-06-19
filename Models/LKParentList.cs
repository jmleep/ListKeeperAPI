namespace ListKeeperAPI.Models
{
    public class LKParentList: LKCompletable
    {
        public int ID { get; set; }
        public virtual List<LKSubList> SubLists { get; set; }
   
    }
}
