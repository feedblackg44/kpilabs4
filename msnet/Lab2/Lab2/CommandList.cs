using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public enum Commands
    {
        AllWorkers = 0,
        AllNames = 1,
        NewObj = 2,
        Where = 3,
        Sort = 4,
        Cartesian = 5,
        InnerJoin = 6,
        GroupJoin = 7,
        CrossJoin = 8,
        OuterJoin = 9,
        Distinct = 10,
        Union = 11,
        Concat = 12,
        Intersect = 13,
        Grouping = 14,
    }
    public class CommandList
    {
        private QueryStringCreator _creator;
        private Dictionary<Commands, Command> _commands;
        public CommandList(Dictionary<DataNames, string> filenames)
        {
            _creator = new QueryStringCreator(filenames);
            _commands = new Dictionary<Commands, Command> {
                { Commands.AllWorkers, new Command() { queryPrint = _creator.AllWorkers } },
                { Commands.AllNames,   new Command() { queryPrint = _creator.AllNames } },
                { Commands.NewObj,     new Command() { queryPrint = _creator.NewObj } },
                { Commands.Where,      new Command() { queryPrint = _creator.Where } },
                { Commands.Sort,       new Command() { queryPrint = _creator.Sort } },
                { Commands.Cartesian,  new Command() { queryPrint = _creator.Cartesian } },
                { Commands.InnerJoin,  new Command() { queryPrint = _creator.InnerJoin } },
                { Commands.GroupJoin,  new Command() { queryPrint = _creator.GroupJoin } },
                { Commands.CrossJoin,  new Command() { queryPrint = _creator.CrossJoin } },
                { Commands.OuterJoin,  new Command() { queryPrint = _creator.OuterJoin } },
                { Commands.Distinct,   new Command() { queryPrint = _creator.Distinct } },
                { Commands.Union,      new Command() { queryPrint = _creator.Union } },
                { Commands.Concat,     new Command() { queryPrint = _creator.Concat } },
                { Commands.Intersect,  new Command() { queryPrint = _creator.Intersect } },
                { Commands.Grouping,   new Command() { queryPrint = _creator.Grouping } }
            };
        }
        public Command this[Commands index]
        { 
            get => _commands[index];
        }
        public Command this[int index]
        {
            get => _commands[(Commands)index];
        }
    }
}
