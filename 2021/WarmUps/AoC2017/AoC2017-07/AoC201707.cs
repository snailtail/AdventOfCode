using System.Collections.Generic;
using System;
using System.Linq;

namespace AoC2017_07
{

    public class ProgramEntity
    {
        public string name { get; private set; }
        public int weight { get; private set; }
        public ProgramEntity parent { get; private set; }

        public List<ProgramEntity> childEntities { get; private set; }
        public List<string> childNames { get; private set; }

        public ProgramEntity(string input)
        {
            var words = input.Words().ToList();

            name = words[0];
            weight = int.Parse(words[1].Shave(1));
            childNames = new List<string>();

            for (var i = 3; i < words.Count; i++)
            {
                childNames.Add(words[i].ShaveRight(","));
            }
        }

        public int GetTotalWeight()
        {
            var childSum = childEntities.Sum(x => x.GetTotalWeight());
            return childSum + weight;
        }

        public void AddChildDiscs(IEnumerable<ProgramEntity> entities)
        {
            childEntities = childNames.Select(x => entities.First(y => y.name == x)).ToList();
            childEntities.ForEach(x => x.parent = this);
        }

        public bool IsBalanced()
        {
            var groups = childEntities.GroupBy(x => x.GetTotalWeight());
            return groups.Count() == 1;
        }

        public (ProgramEntity entity, int targetWeight) GetUnbalancedChild()
        {
            var groups = childEntities.GroupBy(x => x.GetTotalWeight());
            var targetWeight = groups.First(x => x.Count() > 1).Key;
            var unbalancedChild = groups.First(x => x.Count() == 1).First();

            return (unbalancedChild, targetWeight);
        }

    }

    public static class AoC201707
    {


        public static ProgramEntity getRootEntity(IEnumerable<ProgramEntity> entities)
        {
            var entity = entities.First();

            while (entity.parent != null)
            {
                entity = entity.parent;
            }

            return entity;
        }

        public static string Step1(string input)
        {
            var lines = input.Lines();

            var entities = lines.Select(x => new ProgramEntity(x)).ToList();
            entities.ForEach(x => x.AddChildDiscs(entities));

            return getRootEntity(entities).name;
        }
        public static string Step2(string input)
        {


            var lines = input.Lines();

            var programs = lines.Select(x => new ProgramEntity(x)).ToList();
            programs.ForEach(x => x.AddChildDiscs(programs));

            var entity = getRootEntity(programs);
            var targetWeight = 0;

            while (!entity.IsBalanced())
            {
                (entity, targetWeight) = entity.GetUnbalancedChild();
            }

            var weightDiff = targetWeight - entity.GetTotalWeight();
            return (entity.weight + weightDiff).ToString();
        }

        public static IEnumerable<string> Lines(this string input)
        {
            return input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static IEnumerable<string> Words(this string input)
        {
            return input.Split(new string[] { " ", "\t", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string Shave(this string a, int characters)
        {
            return a.Substring(characters, a.Length - (characters * 2));
        }

        public static string ShaveRight(this string a, string removeThis)
        {
            return a.Replace(removeThis, "");
        }

    }
}
