using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace EasyType.Models
{
    public class TrainingHistory
    {
        private const string HistoryFilePath = "training_history.json";
        private List<TrainingResult> _results;

        public TrainingHistory()
        {
            _results = LoadResults();
        }

        public IReadOnlyList<TrainingResult> Results => _results.AsReadOnly();

        public void AddResult(TrainingResult result)
        {
            _results.Add(result);
            SaveResults();
        }

        public void ClearHistory()
        {
            _results.Clear();
            SaveResults();
        }

        private List<TrainingResult> LoadResults()
        {
            if (File.Exists(HistoryFilePath))
            {
                try
                {
                    string jsonString = File.ReadAllText(HistoryFilePath);
                    return JsonSerializer.Deserialize<List<TrainingResult>>(jsonString) ?? new List<TrainingResult>();
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error loading training history: {ex.Message}");
                    return new List<TrainingResult>();
                }
            }
            return new List<TrainingResult>();
        }

        private void SaveResults()
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(_results, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(HistoryFilePath, jsonString);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error saving training history: {ex.Message}");
            }
        }
    }
}