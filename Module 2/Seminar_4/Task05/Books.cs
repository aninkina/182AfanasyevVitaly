using System;

namespace Task05
{
    public class Books : UnitsBase
    {
        private int no_of_pages; // количество страниц в книге
        private bool _isBestSeller; // является ли бестселлером

        public int NoOfPages { get => no_of_pages; private set => no_of_pages = value; }
        public bool IsBestSeller { get => _isBestSeller; private set => _isBestSeller = value; }

        public Books(int unit_code, double price, string name, 
                int noOfPages, bool isBestSeller) : base(unit_code, price, name)
        {
            NoOfPages = noOfPages;
            IsBestSeller = isBestSeller;
        }
        
        public override string ToString()
        {
            return $"Book: Name: {Name}, Unit code: {UnitCode}, № of pages: {NoOfPages}, Best seller: {(IsBestSeller ? "Yes" : "No")}";
        }
    }
}
