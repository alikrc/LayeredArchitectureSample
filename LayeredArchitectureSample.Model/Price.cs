﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredArchitectureSample.Model
{
    public class Price
    {
        private decimal _rrp;
        public decimal RRP
        {
            get { return _rrp; }
        }
        
        private decimal _sellingPrice;
        public decimal SellingPrice
        {
            get { return _discountStrategy.ApplyExtraDiscountsTo(_sellingPrice); }
        }

        public decimal Discount
        {
            get
            {
                if (RRP > SellingPrice)
                    return (RRP - SellingPrice);
                else
                    return 0;
            }
        }

        public decimal Savings
        {
            get
            {
                if (RRP > SellingPrice)
                    return 1 - (SellingPrice / RRP);
                else
                    return 0;
            }
        }

        private IDiscountStrategy _discountStrategy = new NullDiscountStrategy();

        public Price(decimal RRP, decimal SellingPrice)
        {
            _rrp = RRP;
            _sellingPrice = SellingPrice;
        }

        public void SetDiscountStrategyTo(IDiscountStrategy DiscountStrategy)
        {
            _discountStrategy = DiscountStrategy;
        }

    }
}
