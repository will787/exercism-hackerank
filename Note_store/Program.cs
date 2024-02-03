using System;
using System.Collections.Generic;
using System.IO;

namespace Solution
{

    public class NotesStore
    {
        public NotesStore()
        {
            entrada = new List<String>();
        }
        public List<String> entrada {get ; set;}
        public void AddNote(String state, String name) {
            if (string.IsNullOrEmpty(name))
            {
            throw new Exception("O nome não pode estar vazio.");
            }
            if (!(state.Equals("concluido", StringComparison.OrdinalIgnoreCase) ||
                state.Equals("ativo", StringComparison.OrdinalIgnoreCase) ||
                state.Equals("outros", StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception($"Estado inválido: {state}.");
            }
            entrada.Add($"{name} {state}");
        }
        public List<String> GetNotes(String state) {
            if (!(state.Equals("concluido", StringComparison.OrdinalIgnoreCase) ||
            state.Equals("ativo", StringComparison.OrdinalIgnoreCase) ||
            state.Equals("outros", StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception($"Estado inválido: {state}.");
            }
            List<String> result = new List<string>();
            foreach(var item in entrada){
                if(item.Contains(state)){
                    result.Add(item);
                } 
            }
            return result;
        }
    } 

    public class Solution
    {
        public static void Main() 
        {
            var notesStoreObj = new NotesStore();
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; i++) {
                var operationInfo = Console.ReadLine().Split(' ');
                try
                {
                    if (operationInfo[0] == "AddNote")
                        notesStoreObj.AddNote(operationInfo[1], operationInfo.Length == 2 ? "" : operationInfo[2]);
                    else if (operationInfo[0] == "GetNotes")
                    {
                        var result = notesStoreObj.GetNotes(operationInfo[1]);
                        if (result.Count == 0)
                            Console.WriteLine("No Notes");
                        else
                            Console.WriteLine(string.Join(",", result));
                    } else {
                        Console.WriteLine("Invalid Parameter");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }
    }
}