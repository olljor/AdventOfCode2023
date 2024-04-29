// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

/*
 * Ze Plan:
 * Platform handler which sets up the platform as a list of lists of strings
 * Where every string is the the column of the platform (input)
 *      We are only interested in the vertical lines because we are only tilting the platform north    
 * When platform set up, tilt platform by moving every O to the index+1 of previous # or O
 * Then calculate weight by taking the list.count - index+1 of every O 
 */