using System;
using System.Collections.Generic;
using System.Linq;
using EasyType.Models;

namespace EasyType.Models
{
    public class TrainingHistory
    {
        private readonly List<TrainingResult> _results = new();

        public void AddResult(TrainingResult result) => _results.Add(result);

        public List<TrainingResult> GetAllResults() => _results.ToList();

        public List<TrainingResult> GetRecentResults(int count) => _results.OrderByDescending(r => r.DateTime).Take(count).ToList();
    }
}