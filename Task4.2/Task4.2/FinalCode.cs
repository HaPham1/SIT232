using System;
using System.Collections.Generic;
using System.Text;

namespace Task4._2
{
    class CatList
    {
        //List that hold the members of categories
        private List<string[]> _catList;

        //List that hold category names
        private List<string> _catNames;

        //Two list that hold indexes for highlighted tasks
        private List<int> _cat;
        private List<int> _task;

        //Variable that increase and decrease the length of the row in the table.
        private int _maxRowLength = 4;

        public CatList()
        {
            _catList = new List<string[]>();
            _catNames = new List<string>();
            _cat = new List<int>();
            _task = new List<int>();
        }

        public void AddCategory(string[] category, string name)
        {
            _catList.Add(category);
            _catNames.Add(name);
            _maxRowLength += 31;
        }

        public void RemoveCategory(int index, string name)
        {
            _catList.Remove(_catList[index]);
            _catNames.Remove(name);
            _maxRowLength -= 31;
        }

        public int GetIndex(String name)
        {
            for (int i = 0; i < _catNames.Count; i++)
            {
                if (name.ToLower() == _catNames[i].ToLower())
                {
                    return i;
                }
            }
            return -1;
        }
        public void HighlightIndex(int index, int index2)
        {
            _cat.Add(index);
            _task.Add(index2);
        }
        //Properties
        public List<string[]> CateList
        {
            get { return _catList; }
        }

        public List<String> NameList
        {
            get { return _catNames; }
        }

        public int rowMax
        {
            get { return _maxRowLength; }
        }

        public List<int> Index
        {
            get { return _cat; }
        }

        public List<int> Index2
        {
            get { return _task; }
        }
    }

}
