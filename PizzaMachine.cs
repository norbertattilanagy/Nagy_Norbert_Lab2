using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.ComponentModel;

namespace Nagy_Norbert_Lab2
{
    class PizzaMachine : Component
    {
        public delegate void PizzaCompleteDelegate();
        public event PizzaCompleteDelegate PizzaComplete;
        public delegate void DoughnutCompleteDelegate();
        DispatcherTimer pizzaBakeTimer;
        private PizzaType mIngredients;
        public PizzaMachine()
        {
            InitializeComponent();
        }
        public PizzaType Ingredients
        {
            get 
            {
                return mIngredients;
            } 
            set
            { 
                mIngredients = value;
            }
        }// end PizzaMachine class
        private System.Collections.ArrayList mPizzas = new System.Collections.ArrayList();


        public Pizza this[int Index]
        { 
            get
            { 
                return (Pizza)mPizzas[Index];
            } 
            set 
            { 
                mPizzas[Index] = value;
            }
        }// end PizzaMachine class
        private void InitializeComponent()
        {
            this.pizzaBakeTimer = new DispatcherTimer();
            this.pizzaBakeTimer.Tick += new System.EventHandler(this.pizzaBakeTimer_Tick);
        }
        private void pizzaBakeTimer_Tick(object sender, EventArgs e)
        {
            Pizza aPizza = new Pizza(this.Ingredients);
            mPizzas.Add(aPizza);
            PizzaComplete();
        }
        public bool Enabled
        {
            set
            {
                pizzaBakeTimer.IsEnabled = value;
            }
        }
        public int Interval
        {
            set
            {
                pizzaBakeTimer.Interval = new TimeSpan(0, 0, value);
            }
        }
        public void MakePizzas(PizzaType dIngredients)
        {
            Ingredients = dIngredients;
            switch (Ingredients)
            {
                case PizzaType.Canibale: Interval = 3; break;
                case PizzaType.Margherita: Interval = 2; break;
                case PizzaType.Pepperoni: Interval = 5; break;
                case PizzaType.Quattro_Stagioni: Interval = 7; break;
                case PizzaType.Veggie: Interval = 4; break;
            }
            pizzaBakeTimer.Start();
        }
    }// end PizzaMachine class
enum PizzaType 
    { 
        Margherita,
        Pepperoni,
        Veggie,
        Quattro_Stagioni,
        Canibale
    }
    class Pizza
    {
        private PizzaType mIngredients; // câmp
        public PizzaType Ingredients // proprietate
        {
            get //metoda get
            {
                return mIngredients;
            }
            set //metoda set
            {
                mIngredients = value;
            }
        }
        private float mPrice = .50F;
        private float Price
        {
            get
            {
                return mPrice;
            }
            set
            {
                mPrice = value;
            }
        }
        private readonly DateTime mTimeOfCreation;
        public DateTime TimeOfCreation
        {
            get
            {
                return mTimeOfCreation;
            }
        }
        public Pizza(PizzaType aIngredients) // constructor
        {
            mTimeOfCreation = DateTime.Now;
            mIngredients = aIngredients;
        }
    }// end Pizza class
}
