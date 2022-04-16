using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Container : MonoBehaviour {
    private class ContainerItem {
        public System.Guid Id;
        public string Name;
        public int Maximum;

        private int amountTaken;

        public ContainerItem() {
            Id = System.Guid.NewGuid();
        }

        public int Remaining {
            get {
                return Maximum - amountTaken;
            }
        }

        public int Get(int value) {
            if (amountTaken + value > Maximum) { 
                int toMuch = (amountTaken + value) - Maximum;
                amountTaken = Maximum;
                return value - toMuch;
            }

            amountTaken += value;
            return value;
        }
    };

    List<ContainerItem> items;

    void Awake() {
        items = new List<ContainerItem>();
    }

    public System.Guid Add(string name, int maximum) {
        items.Add(new ContainerItem {
            Maximum = maximum,
            Name = name
        });

        return items.Last().Id;
    }

    public int TakeFromContainer(System.Guid id, int amount) {
        var containerItem = items.Where(x => x.Id == id).FirstOrDefault();
        if (containerItem == null) {
            return -1;
        }

        return containerItem.Get(amount);
    }



}
