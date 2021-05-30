using System;

/*
 *Клас для зберіграння інформації про користувачів
 */
namespace SofiaSpack.Code
{
    public class Users
    {
        public String name { get; set; }
        public String password { get; set; }

        public int[] CurrentSection { get; set; } = new int[] { 0, 0 };
        public int[] TestingAlgebra { get; set; } = new int[] { 0, 0, 0, 0};
        public int[] TestingGeometry { get; set; } = new int[] { 0, 0 };
        public int NumberTrialZNO { get; set; } = 0;

        public int[] AlgebraScores { get; set; } = new int[] { 0, 0, 0, 0 };
        public int[] AlgebraRating { get; set; } = new int[] { 0, 0, 0, 0 };
        public int[] ReAlgebraScores { get; set; } = new int[] { 0, 0, 0, 0 };
        public int[] ReAlgebraRating { get; set; } = new int[] { 0, 0, 0, 0 };


        public int[] GeometryScores { get; set; } = new int[] { 0, 0 };
        public int[] GeometryRating { get; set; } = new int[] { 0, 0 };
        public int[] ReGeometryScores { get; set; } = new int[] { 0, 0 };
        public int[] ReGeometryRating { get; set; } = new int[] { 0, 0 };

        public int[] Trial1Scores { get; set; } = new int[] { 0, 0 };
        public int[] Trial2Scores { get; set; } = new int[] { 0, 0 };
        public int[] Trial3Scores { get; set; } = new int[] { 0, 0 };
    }
}
