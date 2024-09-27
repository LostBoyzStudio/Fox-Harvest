using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxItems; // Quantidade máxima de itens no inventário
    private Dictionary<Item, InventorySlot> items = new Dictionary<Item, InventorySlot>(); // Dicionário para armazenar os itens e suas quantidades

    // Define o tipo de evento para adição e remoção de itens
    public event Action<Item, int> OnItemAdded; // Evento para adicionar itens
    public event Action<Item, int> OnItemRemoved; // Evento para remover itens

    public bool HasItem(Item item)
    {
        return items.ContainsKey(item);
    }

    public bool HasAmount(Item item, int amount)
    {
        return items.ContainsKey(item) && items[item].Quantity >= amount;
    }

    public void AddItem(Item item, int amount)
    {
        if (items.ContainsKey(item))
        {
            items[item].Quantity += amount;
        }
        else
        {
            items[item] = new InventorySlot { Quantity = amount, MaxQuantity = item.MaxQuantity, StackLimit = item.StackLimit };
        }

        OnItemAdded?.Invoke(item, amount); // Emitir evento de adição de item
    }

    public void RemoveItem(Item item, int amount)
    {
        if (items.ContainsKey(item))
        {
            items[item].Quantity -= amount;
            if (items[item].Quantity <= 0)
            {
                items.Remove(item);
            }

            OnItemRemoved?.Invoke(item, amount); // Emitir evento de remoção de item
        }
    }
}