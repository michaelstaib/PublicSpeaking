using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace StarWarsClientDemo
{
    public class Review
        : IReview
    {
        public Review(
            int stars)
        {
            Stars = stars;
        }

        public int Stars { get; }
    }
}
