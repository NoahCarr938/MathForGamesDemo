using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MathForGamesDemo
{
    internal class Actor
    {
        private bool _started = false;
        private bool _enabled = true;

        private Component[] _components;
        private Component[] _componentsToRemove;

        public bool Started { get => _started; }

        public bool Enabled
        {
            get => _enabled;
            set
            {
                // If enabled would not change, do nothing
                if (_enabled == value) return;

                _enabled = value;
                // If value is true, call OnEnabled
                if (_enabled)
                    OnEnable();
                // If value is false, call OnDisabled
                else
                    OnDisable();
            }
        }
        public String Name { get; set; }
        public Transform2D Transform { get; protected set; }

        public Actor(string name = "Actor")
        {
            Name = name;
            Transform = new Transform2D(this);
            _components = new Component[0];
            _componentsToRemove = new Component[0];
        }

        public static Actor Instantiate(
            Actor actor,
            Transform2D parent = null,
            Vector2 position = new Vector2(),
            float rotaion = 0,
            string Name = "Actor")
        {

            // set actor transform values
            actor.Transform.LocalPosition = position;
            actor.Transform.Rotate(rotaion);
            actor.Name = Name;
            if (parent != null)
                parent.AddChild(actor.Transform);

            // Add actor to current scene
            Game.CurrentScene.AddActor(actor);

            return actor;
        }


        public static void Destroy(Actor actor)
        {
            // Remove all children
            foreach (Transform2D child in actor.Transform.Children)
            {
                actor.Transform.RemoveChild(child);
            }

            // Unchild from parent
            if (actor.Transform.Parent != null)
                actor.Transform.Parent.RemoveChild(actor.Transform);

            Game.CurrentScene.RemoveActor(actor);
        }

        public virtual void OnEnable()
        {

        }

        public virtual void OnDisable()
        {

        }

        public Collider Collider { get; set; }
        public virtual void Start() 
        {
            _started = true;
        }

        public virtual void Update(double deltaTime) 
        {
            // Update all components
            foreach (Component component in _components)
            {
                if (!component.Started)
                    component.Start();

                component.Update(deltaTime);
            }

            // Remove components that should be removed
            RemoveComponentsToBeRemoved();
        }

        public virtual void End() 
        {
            foreach (Component component in _components)
            {
                component.End();
            }
        }

        public virtual void OnCollision(Actor other)
        {

        }

        // Add component
        public T AddComponent<T>(T component) where T : Component
        {

            // Create temporary array one bigger than _components
            Component[] temp = new Component[_components.Length + 1];

            // Deep copy _components into temp
            for (int i = 0; i < _components.Length; i++)
            {
                temp[i] = _components[i];

            }

            // Set the last index in temp to the component we wish to add
            temp[temp.Length - 1] = component;

            // Store temp in _components
            _components = temp;

            return component;
        }

        public T AddComponent<T>() where T : Component, new()
        {
            // Making a new component, the owner is this actor, the result will be a component object and will cast to this class.
            T component = new T();
            component.Owner = this;
            return AddComponent(component);
        }

        // Remove component
        public bool RemoveComponent<T>(T component) where T: Component
        {
            // Edge case for empty component array
            if (_components.Length <= 0)
                return false;

            if (_components.Length == 1 && _components[0] == component)
            {
                // Add component to _componentsToRemove    
                AddComponentToRemove(component);
                return true;
            }

            // Loop through _components
            foreach (Component comp in _components)
            {
                // If this component is the component we want to remove
                if (comp == component)
                {
                    // Add component to _componentsToRemove
                    AddComponentToRemove(comp);

                    // Because we've removed a component, do not continue the loop
                    return true;
                }
            }

            return false;

                //// Edge case for only one component
                //if (_components.Length == 1 && _components[0] == component)
                //{
                //    _components = new Component[0];
                //    return true;
                //}

                //// Create a temp array one smaller than _components
                //Component[] temp = new Component[_components.Length - 1];
                //bool componentRemoved = false;

                //// Deep copy _components into temp minus the one component
                //int j = 0;
                //for (int i = 0; j < _components.Length - 1; i++)
                //{
                //    if (_components[i] != component)
                //    {
                //        temp[j] = _components[i];
                //        j++;
                //    }
                //    else
                //    {
                //        componentRemoved = true;
                //    }
                //}

                //// if a component was removed, assign temp over _components
                //if (componentRemoved)
                //{
                //    component.End();
                //    _components = temp;
                //}
                //return componentRemoved;

            }

            public bool RemoveComponent<T>() where T : Component
        {
            T component = GetComponent<T>();
            if (component != null)
                return RemoveComponent(component);
            return false;
        }
            

        // Get component
        public T GetComponent<T>() where T : Component
        {
            foreach (Component component in _components)
            {
                if (component is T)
                    return (T)component;
            }
            return null;
        }

        // Get components
        public T[] GetComponents<T>() where T: Component
        {
            // Create an array of the same size as _components
            T[] temp = new T[_components.Length];

            // Copy all elements that are of type T into temp
            int count = 0;
            for (int i = 0; i < _components.Length; i++)
            {
                if (_components[i] is T)
                {
                    temp[count] = (T)_components[i];
                    count++;
                }
            }

            // Trim the array
            T[] result = new T[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = temp[i];
            }

            return result;
        }

        private void AddComponentToRemove(Component comp)
        {
            // Ensure component is not already being removed
            foreach (Component component in _componentsToRemove)
            {
                if (component == comp)
                    return;
            }
            // Create temporary array one bigger than _componentsToRemove
            Component[] temp = new Component[_componentsToRemove.Length + 1];

            // Deep copy _componentsToRemove into temp
            for (int i = 0; i < _componentsToRemove.Length; i++)
            {
                temp[i] = _componentsToRemove[i];
            }

            // Set the last index in temp to the component we wish to add
            temp[temp.Length - 1] = comp;

            // Store temp in _components
            _componentsToRemove = temp;
        }

        private void RemoveComponentsToBeRemoved()
        {
            // If there are no components to remove, return
            if (_componentsToRemove.Length <= 0)
                return;

            // Create temp array for _components
            Component[] tempComponents = new Component[_components.Length];
            // Create temp array for _componentsToRemove
            Component[] tempComponentsToRemove = new Component[_componentsToRemove.Length];

            // Deep copy the array, removing the elements in _componentsToRemove
            int j = 0;
            for (int i = 0; i < _components.Length; i++)
            {
                // Loop through components to check if any of them is equal to this one
                bool removed = false;
                foreach (Component component in _componentsToRemove)
                {
                    if (_components[i] == component)
                    {
                        removed = true;
                        component.End();
                        break;
                    }
                }

                // If we did not find one to remove, copy the item and increment the temp array
                if (!removed)
                {
                    tempComponents[j] = _components[i];
                    j++;
                }

            }

            // Trim the array
            Component[] result = new Component[_components.Length - _componentsToRemove.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = tempComponents[i];
            }

            // Set _components
            _components = result;
        }
    }
}
