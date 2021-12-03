using System;
using System.Collections.Generic;
using System.Text;

namespace HashTables
{
    public class Hash<K, V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;
        public Hash(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size] ;
        }
        protected int GetArrayposition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        public V Get(K key)
        {
            int position = GetArrayposition(key);
            LinkedList<KeyValue<K, V>> LinkedList = GetLinkedList(position);
            foreach(KeyValue<K, V> item in LinkedList)
            {
                if(item.key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }
        public void Add(K key, V value)
        {
            int position = GetArrayposition(key);
            LinkedList<KeyValue<K, V>> LinkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { key = key, Value = value };
            LinkedList.AddLast(item);
        }
        public void Remove(K key)
        {
            int position = GetArrayposition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFOund = false;
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach(KeyValue<K,V> item in linkedList)
            {
                if (item.key.Equals(key))
                {
                    itemFOund = true;
                    foundItem = item;
                }
            }
            if(itemFOund)
            {
                linkedList.Remove(foundItem);
            }                
        }
        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if(linkedList ==null )
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
    }
    public struct KeyValue<k,v>
    {
        public k key { get; set; }
        public v Value { get; set; }
    }
}
