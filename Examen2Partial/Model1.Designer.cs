﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("TodoDBModel", "FK_todos_usuarios", "usuarios", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Examen2Partial.usuario), "todos", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Examen2Partial.todo), true)]

#endregion

namespace Examen2Partial
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class TodoDBEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new TodoDBEntities object using the connection string found in the 'TodoDBEntities' section of the application configuration file.
        /// </summary>
        public TodoDBEntities() : base("name=TodoDBEntities", "TodoDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new TodoDBEntities object.
        /// </summary>
        public TodoDBEntities(string connectionString) : base(connectionString, "TodoDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new TodoDBEntities object.
        /// </summary>
        public TodoDBEntities(EntityConnection connection) : base(connection, "TodoDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<todo> todos
        {
            get
            {
                if ((_todos == null))
                {
                    _todos = base.CreateObjectSet<todo>("todos");
                }
                return _todos;
            }
        }
        private ObjectSet<todo> _todos;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<usuario> usuarios
        {
            get
            {
                if ((_usuarios == null))
                {
                    _usuarios = base.CreateObjectSet<usuario>("usuarios");
                }
                return _usuarios;
            }
        }
        private ObjectSet<usuario> _usuarios;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the todos EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddTotodos(todo todo)
        {
            base.AddObject("todos", todo);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the usuarios EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddTousuarios(usuario usuario)
        {
            base.AddObject("usuarios", usuario);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="TodoDBModel", Name="todo")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class todo : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new todo object.
        /// </summary>
        /// <param name="idTodo">Initial value of the idTodo property.</param>
        /// <param name="descripcion">Initial value of the descripcion property.</param>
        /// <param name="fechaI">Initial value of the fechaI property.</param>
        /// <param name="fechaF">Initial value of the fechaF property.</param>
        /// <param name="status">Initial value of the status property.</param>
        /// <param name="userOwner">Initial value of the userOwner property.</param>
        /// <param name="nombre">Initial value of the nombre property.</param>
        public static todo Createtodo(global::System.Int32 idTodo, global::System.String descripcion, global::System.DateTime fechaI, global::System.DateTime fechaF, global::System.String status, global::System.String userOwner, global::System.String nombre)
        {
            todo todo = new todo();
            todo.idTodo = idTodo;
            todo.descripcion = descripcion;
            todo.fechaI = fechaI;
            todo.fechaF = fechaF;
            todo.status = status;
            todo.userOwner = userOwner;
            todo.nombre = nombre;
            return todo;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 idTodo
        {
            get
            {
                return _idTodo;
            }
            set
            {
                if (_idTodo != value)
                {
                    OnidTodoChanging(value);
                    ReportPropertyChanging("idTodo");
                    _idTodo = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("idTodo");
                    OnidTodoChanged();
                }
            }
        }
        private global::System.Int32 _idTodo;
        partial void OnidTodoChanging(global::System.Int32 value);
        partial void OnidTodoChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                OndescripcionChanging(value);
                ReportPropertyChanging("descripcion");
                _descripcion = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("descripcion");
                OndescripcionChanged();
            }
        }
        private global::System.String _descripcion;
        partial void OndescripcionChanging(global::System.String value);
        partial void OndescripcionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime fechaI
        {
            get
            {
                return _fechaI;
            }
            set
            {
                OnfechaIChanging(value);
                ReportPropertyChanging("fechaI");
                _fechaI = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("fechaI");
                OnfechaIChanged();
            }
        }
        private global::System.DateTime _fechaI;
        partial void OnfechaIChanging(global::System.DateTime value);
        partial void OnfechaIChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime fechaF
        {
            get
            {
                return _fechaF;
            }
            set
            {
                OnfechaFChanging(value);
                ReportPropertyChanging("fechaF");
                _fechaF = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("fechaF");
                OnfechaFChanged();
            }
        }
        private global::System.DateTime _fechaF;
        partial void OnfechaFChanging(global::System.DateTime value);
        partial void OnfechaFChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String status
        {
            get
            {
                return _status;
            }
            set
            {
                OnstatusChanging(value);
                ReportPropertyChanging("status");
                _status = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("status");
                OnstatusChanged();
            }
        }
        private global::System.String _status;
        partial void OnstatusChanging(global::System.String value);
        partial void OnstatusChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String userOwner
        {
            get
            {
                return _userOwner;
            }
            set
            {
                OnuserOwnerChanging(value);
                ReportPropertyChanging("userOwner");
                _userOwner = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("userOwner");
                OnuserOwnerChanged();
            }
        }
        private global::System.String _userOwner;
        partial void OnuserOwnerChanging(global::System.String value);
        partial void OnuserOwnerChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                OnnombreChanging(value);
                ReportPropertyChanging("nombre");
                _nombre = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("nombre");
                OnnombreChanged();
            }
        }
        private global::System.String _nombre;
        partial void OnnombreChanging(global::System.String value);
        partial void OnnombreChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("TodoDBModel", "FK_todos_usuarios", "usuarios")]
        public usuario usuario
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<usuario>("TodoDBModel.FK_todos_usuarios", "usuarios").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<usuario>("TodoDBModel.FK_todos_usuarios", "usuarios").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<usuario> usuarioReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<usuario>("TodoDBModel.FK_todos_usuarios", "usuarios");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<usuario>("TodoDBModel.FK_todos_usuarios", "usuarios", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="TodoDBModel", Name="usuario")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class usuario : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new usuario object.
        /// </summary>
        /// <param name="email">Initial value of the email property.</param>
        /// <param name="password">Initial value of the password property.</param>
        public static usuario Createusuario(global::System.String email, global::System.String password)
        {
            usuario usuario = new usuario();
            usuario.email = email;
            usuario.password = password;
            return usuario;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email != value)
                {
                    OnemailChanging(value);
                    ReportPropertyChanging("email");
                    _email = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("email");
                    OnemailChanged();
                }
            }
        }
        private global::System.String _email;
        partial void OnemailChanging(global::System.String value);
        partial void OnemailChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String password
        {
            get
            {
                return _password;
            }
            set
            {
                OnpasswordChanging(value);
                ReportPropertyChanging("password");
                _password = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("password");
                OnpasswordChanged();
            }
        }
        private global::System.String _password;
        partial void OnpasswordChanging(global::System.String value);
        partial void OnpasswordChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("TodoDBModel", "FK_todos_usuarios", "todos")]
        public EntityCollection<todo> todos
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<todo>("TodoDBModel.FK_todos_usuarios", "todos");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<todo>("TodoDBModel.FK_todos_usuarios", "todos", value);
                }
            }
        }

        #endregion

    }

    #endregion

    
}
