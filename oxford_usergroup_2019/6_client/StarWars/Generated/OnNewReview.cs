using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace StarWarsClientDemo
{
    public class OnNewReview
        : IOnNewReview
    {
        public OnNewReview(
            IReview onReview)
        {
            OnReview = onReview;
        }

        public IReview OnReview { get; }
    }
}
