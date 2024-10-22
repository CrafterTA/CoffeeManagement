using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALIngredient
    {
        private static DALIngredient _instance;
        public static DALIngredient Instance
        {
            get
            {
                if (_instance == null) _instance = new DALIngredient();
                return _instance;
            }
            set => _instance = value;
        }
        public List<Ingredient> GetAllIngredients()
        {
            return CafeEntities.Instance.Ingredients.ToList();
        }
        public Ingredient GetIngredientByID(string ingredientID)
        {
            return CafeEntities.Instance.Ingredients.Find(ingredientID);
        }
        public bool AddIngredient(string ingredientID, string ingredientName, string unit, decimal unitPrice, decimal stock)
        {
            try
            {
                Ingredient ingredient = new Ingredient()
                {
                    IngredientID = ingredientID,
                    IngredientName = ingredientName,
                    Unit = unit,
                    UnitPrice = unitPrice,
                    Stock = stock
                };
                CafeEntities.Instance.Ingredients.Add(ingredient);
                CafeEntities.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateIngredient(Ingredient ingredient)
        {
            try
            {
                var itu = CafeEntities.Instance.Ingredients.Find(ingredient.IngredientID);
                itu.IngredientName = ingredient.IngredientName;
                itu.Unit = ingredient.Unit;
                itu.UnitPrice = ingredient.UnitPrice;
                itu.Stock = ingredient.Stock;
                CafeEntities.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteIngredient(string ingredientID)
        {
            try
            {
                var ingredientToDelete = CafeEntities.Instance.Ingredients.Find(ingredientID);
                CafeEntities.Instance.Ingredients.Remove(ingredientToDelete);
                CafeEntities.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
