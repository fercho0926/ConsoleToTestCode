﻿using Generics.Generics.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics.Generics.Repositories
{
    public class GenericRepository<T> where T :   IEntity
    {
        protected readonly List<T> _items = new List<T>();


        public T GetById(int id) => _items.Single(item => item.Id == id);

        public void Add(T item)
        {
            item.Id = _items.Any() ? _items.Max(item => item.Id) + 1 : 1;
            _items.Add(item);
        }

        public void Save()
        {
            foreach (var Item in _items)
            {
                Console.WriteLine(Item);
            }

        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }
    }

  
}
