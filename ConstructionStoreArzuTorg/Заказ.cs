//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConstructionStoreArzuTorg
{
    using System;
    using System.Collections.Generic;
    
    public partial class Заказ
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Заказ()
        {
            this.ВозвратТовара = new HashSet<ВозвратТовара>();
            this.ЗаказанныеТовары = new HashSet<ЗаказанныеТовары>();
        }
    
        public int ID_Заказа { get; set; }
        public Nullable<int> ID_Клиента { get; set; }
        public int ID_Сотрудника { get; set; }
        public decimal Сумма { get; set; }
        public System.DateTime Дата_заказа { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ВозвратТовара> ВозвратТовара { get; set; }
        public virtual Клиент Клиент { get; set; }
        public virtual Сотрудник Сотрудник { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ЗаказанныеТовары> ЗаказанныеТовары { get; set; }
    }
}
