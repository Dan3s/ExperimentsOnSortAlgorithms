using SortAlgorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentsOnSortAlgorithms
{
	public class SortAlgorithms
	{
		public const String ORDEN_ASCENDENTE = "Ascendente";
		public const String ORDEN_DESCENDENTE = "Descendente";
		public const String ORDEN_ALEATORIO = "Aleatorio";

		public const String ORDEN_POR_BURBUJA = "Burbuja";
        public const String ORDEN_POR_SELECCION = "Seleccion";

        private Treatment[] basicTreatment;

        internal Treatment[] BasicTreatment { get => basicTreatment; set => basicTreatment = value; }

        public void BubbleSort(int[] arr)
		{
			int temp = 0;
			for (int write = 0; write < arr.Length; write++)
			{
				for (int sort = 0; sort < arr.Length - 1; sort++)
				{
					if (arr[sort] > arr[sort + 1])
					{
						temp = arr[sort + 1];
						arr[sort + 1] = arr[sort];
						arr[sort] = temp;
					}
				}
			}
		}


		public void SelectionSort(int[] ar)
		{
			//int[] ar = { 5, 3, 7, 2 };
			int n = ar.Length;
			for (int x = 0; x < n; x++)
			{
				int min_index = x;
				for (int y = x; y < n; y++)
				{
					if (ar[min_index] > ar[y])
					{
						min_index = y;
					}
				}
				int temp = ar[x];
				ar[x] = ar[min_index];
				ar[min_index] = temp;
			}

		}
		public int[] CreateVector()
		{
			int[] indexV = { 10, 100, 1000, 10000, 100000 };

			Random rnd = new Random();
			int index = rnd.Next(0, 4);
			int[] vector = new int[indexV[index]];

			Random rnd2 = new Random();
			int value = 0;

			for (int i = 0; i < vector.Length; i++)
			{
				value = rnd2.Next(0, indexV[index]);
				vector[i] = value;
			}

			return vector;


		}

		public bool DescendingOrder(int[] vector)
		{
			bool isOrdered = true;
			int last = vector[0];

			for (int i = 1; i < vector.Length; i++)
			{
				if (vector[i] > last) isOrdered = false;
				last = vector[i];
			}

			return isOrdered;
		}

		public bool AscendingOrder(int[] vector)
		{
			bool isOrdered = true;
			int last = vector[0];

			for (int i = 1; i < vector.Length; i++)
			{
				if (vector[i] < last) isOrdered = false;
				last = vector[i];
			}

			return isOrdered;
		}
		/**
		 * Ordena de forma aleatoria el arreglo de entrada
		 *
		 */
		public int[] RandomOrder(int[] arr)
		{
			Random rnd = new Random();
			int[] MyRandomArray = arr.OrderBy(x => rnd.Next()).ToArray();
			return MyRandomArray;
		}

		/**
		 * Metodo para definir el experimento
		 */
		public void DefineProof(int tamañoArreglo, String ordenArreglo, String ram, String algoritmoDeOrden)
		{
			//--------------------------------------------
			// Crea un arreglo de tamañoArreglo y lo inicializa aleatoriamente (orden aleatorio determinado)
			//--------------------------------------------
			int[] array = new int[tamañoArreglo];
			Random rnd2 = new Random();
			int value = 0;

            if (ordenArreglo.Equals(ORDEN_ASCENDENTE, StringComparison.InvariantCultureIgnoreCase)) {

			    for (int i = 0; i < array.Length; i++)
			    {
                    array[i] = i;
                }

            }else if (ordenArreglo.Equals(ORDEN_DESCENDENTE, StringComparison.InvariantCultureIgnoreCase)) {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = array.Length - i;

                }
            }
            else {

                for (int i = 0; i < array.Length; i++)
                {
                    value = rnd2.Next(0, tamañoArreglo);
			        array[i] = value;
                }
            }




            //-------------------------------------------------
            //Ordena el arreglo de acuerdo a ordenArreglo
            //-------------------------------------------------
            //if (ordenArreglo.Equals(ORDEN_ASCENDENTE, StringComparison.InvariantCultureIgnoreCase))
            //{
            //    Array.Sort(array);
            //}
            //else if (ordenArreglo.Equals(ORDEN_DESCENDENTE, StringComparison.InvariantCultureIgnoreCase))
            //{
            //    Array.Sort(array);
            //    Array.Reverse(array);
            //}

            //---------------------------------------------------------
            //Ordenamiento por el algoritmo escogido y toma de datos
            //---------------------------------------------------------
            double tiempo = 0;
			if (algoritmoDeOrden.Equals(ORDEN_POR_BURBUJA, StringComparison.InvariantCultureIgnoreCase))
			{
				TimeSpan stop;
				TimeSpan start = new TimeSpan(DateTime.Now.Ticks);

				BubbleSort(array);

				stop = new TimeSpan(DateTime.Now.Ticks);
				tiempo = stop.Subtract(start).TotalMilliseconds;
			}
			else
			{
				TimeSpan stop;
				TimeSpan start = new TimeSpan(DateTime.Now.Ticks);

				SelectionSort(array);

				stop = new TimeSpan(DateTime.Now.Ticks);
				tiempo = stop.Subtract(start).TotalMilliseconds;
			}
			//----------------------------------------
			//guardar datos de datos
			//----------------------------------------
			GuardarDatos(tamañoArreglo, ram, ordenArreglo, algoritmoDeOrden, tiempo);
		}



		public void GuardarDatos(int tamañoArreglo, String ram, String orden, String algoritmoDeOrdenamiento, double tiempo)
		{
			try
			{

				//Pass the filepath and filename to the StreamWriter Constructor
				
				StreamWriter sw = new StreamWriter("..\\..\\" + algoritmoDeOrdenamiento + ".txt", true);

				//Write a line of text
				sw.WriteLine(algoritmoDeOrdenamiento + "-" + tamañoArreglo + "-" + ram + "-" + orden + "-" + tiempo);

				//Close the file
				sw.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception: " + e.Message);
			}
			/*finally
			{
				Console.WriteLine("Executing finally block.");
			}*/
		}


        public void initializeBasicTreatment() {

            //Se encarga de inicializar 15 tratamientos basicos de donde se deriban los otros
            BasicTreatment = new Treatment[24];

            string[] types = { ORDEN_ASCENDENTE, ORDEN_DESCENDENTE, ORDEN_ALEATORIO};
            int aux = 0;
            for (int i = 1; i<=8; i++) {
                for (int j = 0; j < 3; j++)
                {
                    Treatment treatment = new Treatment(types[j], (int)(Math.Pow((double)10,(double)i)));
                    BasicTreatment[aux] = treatment;
                    aux++;
                }
            }

        }

        public void repetitions(String ram) {
            initializeBasicTreatment();
            //repeticiones para burbuja
            for (int i = 0; i<BasicTreatment.Length; i++) {
                for (int j = 0; j < 10; j++) {
                    DefineProof(BasicTreatment[i].Size,BasicTreatment[i].Order,ram, ORDEN_POR_BURBUJA);
                }
            }

            //repeticiones para seleccion 
            for (int i = 0; i<BasicTreatment.Length; i++) {

                for (int j = 0; j < 10; j++)
                {
                    DefineProof(BasicTreatment[i].Size, BasicTreatment[i].Order, ram, ORDEN_POR_SELECCION);
                }
            }


        }



        public static void Main(String[] args)
		{
			/*int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

			int[] arr2 = { 9, 1, 2, 8, 3, 7, 4, 6, 5, 10 };
			SortAlgorithms sa = new SortAlgorithms();
			//sa.BubbleSort(arr2);
			Array.Sort(arr2);
			Array.Reverse(arr2);
			for (int z = 0; z < arr2.Length; z++)
			{
				Console.WriteLine(arr2[z] + " ");
			}*/
			SortAlgorithms sa = new SortAlgorithms();
            Console.WriteLine("Ingrese 1 si su RAM es de 4GB");
            Console.WriteLine("Ingrese 2 si su RAM es de 8GB");
            int ram = int.Parse(Console.ReadLine());
            if (ram == 1)
            {
                sa.repetitions("4GB");
            }
            else {
                sa.repetitions("8GB");
            }
            Console.WriteLine("Terminado");
            Console.ReadKey();


        
		}
	}

	
}
