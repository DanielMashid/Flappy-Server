using System;
using System.Collections.Generic;

public static class GeneticOperators
{
	public static NeuralNetwork[] Selection(NeuralNetwork[] population)
	{

		Array.Sort(population);
		List<NeuralNetwork> listNextPopulation = new List<NeuralNetwork>();

		// new list with the best fitness
		for(int i = population.Length-1; i > (population.Length / 2); i=i-2)
        {
			listNextPopulation.Add(population[i]);
			listNextPopulation.Add(population[i-1]);
		}

		for(int i = 0; i < population.Length; i++)
        {
			listNextPopulation.Add(population[i]);
		}

		for (int i = 0; i < population.Length; i++)
		{
			population[i] = listNextPopulation[i];
		}
		return population;
	}
	
	public static NeuralNetwork[] CrossOver(NeuralNetwork[] population)
	{
		Random rnd = new Random();
		int hiddenLen = population[0].hidden.Length;
		int first = rnd.Next(0, 100);
		int second = rnd.Next(0, 100);
		HiddenNeuron[] hidden1 = population[first].hidden;
		HiddenNeuron[] hidden2 = population[second].hidden;
		for(int i =0; i< hiddenLen; i++)
        {
            if (i % 2 == 0)
            {
				HiddenNeuron temp = hidden1[i];
				hidden1[i] = hidden2[i];
				hidden2[i] = temp;

			}
        }
		return population;
	}

	public static NeuralNetwork[] Mutation(NeuralNetwork[] population)
	{
		Random rnd = new Random();
		int hiddenLen = population[0].hidden.Length;
		int someone = rnd.Next(0, 100); ;
		int place1 = rnd.Next(0, hiddenLen);
		int place2 = rnd.Next(0, hiddenLen);
		HiddenNeuron[] hidden = population[someone].hidden;
		HiddenNeuron temp = hidden[place1];
		hidden[place1] = hidden[place2];
		hidden[place2] = temp;
		return population;
	}
}