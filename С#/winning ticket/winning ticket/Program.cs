/*
 * Created by SharpDevelop.
 * User: Danis92
 * Date: 28.11.2012
 * Time: 21:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace winning_ticket
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Программа поиска счастливых билетов:");
			
			int i1,i2,i3,i4,i5,i6=0;
			int result=0; // Результат
			
			for (i1=0;i1<10;i1++){
				for (i2=0;i2<10;i2++) 
					for (i3=0;i3<10;i3++) 
						for (i4=0;i4<10;i4++) 
							for (i5=0;i5<10;i5++) 
								for (i6=0;i6<10;i6++) {

									if ((i1+i2+i3)==(i4+i5+i6)) {
									result++;
									}
						   		}
			}
			
			Console.WriteLine("Количество счастливых билетов: {0}",result);
			Console.ReadKey(true);
		}
	}
}