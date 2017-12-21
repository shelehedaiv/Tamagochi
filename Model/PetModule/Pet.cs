using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Model.ConstructionModules.Observer;
using Model.Inventory.Stuff;
using Model.PetModule.Attribute;

namespace Model.PetModule
{
    [DataContract]
    internal class Pet:IListener, IPet
    {
        [DataMember]
        private List<Need> _attributes = new List<Need>()
        {
            new Need(NeedType.Bellyful)
        };

        private LifeTimer _lifeTimer;
        public Pet()
        {
            RestartTimer();
            _listeners = new List<IListener>();
            
        }
       
        #region IPet
        //??????????
        public bool Use(Item item)
        {
            var need = _attributes.First(att => att.Name == item.Usage);
            if (need.Fill(item.Value)) return true;
            else return false;
        }
        public bool Eat(int value)
        {
            if (_attributes.Where(att=>att.Name==NeedType.Bellyful).First().Fill(value))
            {
                return true;
            }
            else return false;
        }
        public Dictionary<string, int> GetState()
        {
            Dictionary<string, int> state=new Dictionary<string, int>();
            foreach (var att in _attributes)
            {
                state.Add(Enum.GetName(typeof(NeedType), att.Name), att.CurrentValue);
            }
            return state;
        }

        public void RestartTimer()
        {
            
            _lifeTimer=new LifeTimer();
            LifeTimer.TimePassed += Update;
            LifeTimer.TimePassed += Notify;

        }
        #endregion
        #region Observer pattern (Listener for timer)

        public void Update()
        {
            foreach (var att in _attributes)
            {
                att.TimePass();
            }
        }

        #endregion
        [DataMember]
        private List<IListener> _listeners;
        public void AttachListener(IListener listener)
        {
            if (_listeners is null)
                _listeners=new List<IListener>();
            _listeners.Add(listener);
        }
        public void Notify()
        {
            foreach (var listener in _listeners)
            {
                listener.Update();
            }
        }
    }
}
