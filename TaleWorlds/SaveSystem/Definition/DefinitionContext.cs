using System;
using System.Collections.Generic;
using System.Reflection;
using TaleWorlds.Library;

namespace TaleWorlds.SaveSystem.Definition;

public class DefinitionContext
{
	private Dictionary<Type, TypeDefinition> _rootClassDefinitions;

	private Dictionary<Type, TypeDefinition> _classDefinitions;

	private Dictionary<SaveId, TypeDefinition> _classDefinitionsWithId;

	private Dictionary<Type, InterfaceDefinition> _interfaceDefinitions;

	private Dictionary<SaveId, InterfaceDefinition> _interfaceDefinitionsWithId;

	private Dictionary<Type, EnumDefinition> _enumDefinitions;

	private Dictionary<SaveId, EnumDefinition> _enumDefinitionsWithId;

	private Dictionary<Type, ContainerDefinition> _containerDefinitions;

	private Dictionary<SaveId, ContainerDefinition> _containerDefinitionsWithId;

	private Dictionary<Type, GenericTypeDefinition> _genericClassDefinitions;

	private Dictionary<Type, StructDefinition> _structDefinitions;

	private Dictionary<SaveId, StructDefinition> _structDefinitionsWithId;

	private Dictionary<Type, GenericTypeDefinition> _genericStructDefinitions;

	private Dictionary<Type, BasicTypeDefinition> _basicTypeDefinitions;

	private Dictionary<SaveId, BasicTypeDefinition> _basicTypeDefinitionsWithId;

	private Dictionary<Type, TypeDefinitionBase> _allTypeDefinitions;

	private Dictionary<SaveId, TypeDefinitionBase> _allTypeDefinitionsWithId;

	private List<IAutoGeneratedSaveManager> _autoGeneratedSaveManagers;

	private Assembly[] _assemblies;

	public List<string> _errors;

	private List<SaveableTypeDefiner> _saveableTypeDefiners;

	public bool GotError => _errors.Count > 0;

	public IEnumerable<string> Errors => _errors.AsReadOnly();

	public DefinitionContext()
	{
		_errors = new List<string>();
		_rootClassDefinitions = new Dictionary<Type, TypeDefinition>();
		_classDefinitions = new Dictionary<Type, TypeDefinition>();
		_classDefinitionsWithId = new Dictionary<SaveId, TypeDefinition>();
		_interfaceDefinitions = new Dictionary<Type, InterfaceDefinition>();
		_interfaceDefinitionsWithId = new Dictionary<SaveId, InterfaceDefinition>();
		_enumDefinitions = new Dictionary<Type, EnumDefinition>();
		_enumDefinitionsWithId = new Dictionary<SaveId, EnumDefinition>();
		_containerDefinitions = new Dictionary<Type, ContainerDefinition>();
		_containerDefinitionsWithId = new Dictionary<SaveId, ContainerDefinition>();
		_genericClassDefinitions = new Dictionary<Type, GenericTypeDefinition>();
		_structDefinitions = new Dictionary<Type, StructDefinition>();
		_structDefinitionsWithId = new Dictionary<SaveId, StructDefinition>();
		_genericStructDefinitions = new Dictionary<Type, GenericTypeDefinition>();
		_basicTypeDefinitions = new Dictionary<Type, BasicTypeDefinition>();
		_basicTypeDefinitionsWithId = new Dictionary<SaveId, BasicTypeDefinition>();
		_allTypeDefinitions = new Dictionary<Type, TypeDefinitionBase>();
		_allTypeDefinitionsWithId = new Dictionary<SaveId, TypeDefinitionBase>();
		_saveableTypeDefiners = new List<SaveableTypeDefiner>();
		_autoGeneratedSaveManagers = new List<IAutoGeneratedSaveManager>();
	}

	internal void AddRootClassDefinition(TypeDefinition rootClassDefinition)
	{
		_rootClassDefinitions.Add(rootClassDefinition.Type, rootClassDefinition);
		_allTypeDefinitions.Add(rootClassDefinition.Type, rootClassDefinition);
		_allTypeDefinitionsWithId.Add(rootClassDefinition.SaveId, rootClassDefinition);
	}

	internal void AddClassDefinition(TypeDefinition classDefinition)
	{
		_classDefinitions.Add(classDefinition.Type, classDefinition);
		_classDefinitionsWithId.Add(classDefinition.SaveId, classDefinition);
		_allTypeDefinitions.Add(classDefinition.Type, classDefinition);
		_allTypeDefinitionsWithId.Add(classDefinition.SaveId, classDefinition);
	}

	internal void AddStructDefinition(StructDefinition structDefinition)
	{
		_structDefinitions.Add(structDefinition.Type, structDefinition);
		_structDefinitionsWithId.Add(structDefinition.SaveId, structDefinition);
		_allTypeDefinitions.Add(structDefinition.Type, structDefinition);
		_allTypeDefinitionsWithId.Add(structDefinition.SaveId, structDefinition);
	}

	internal void AddInterfaceDefinition(InterfaceDefinition interfaceDefinition)
	{
		_interfaceDefinitions.Add(interfaceDefinition.Type, interfaceDefinition);
		_interfaceDefinitionsWithId.Add(interfaceDefinition.SaveId, interfaceDefinition);
		_allTypeDefinitions.Add(interfaceDefinition.Type, interfaceDefinition);
		_allTypeDefinitionsWithId.Add(interfaceDefinition.SaveId, interfaceDefinition);
	}

	internal void AddEnumDefinition(EnumDefinition enumDefinition)
	{
		_enumDefinitions.Add(enumDefinition.Type, enumDefinition);
		_enumDefinitionsWithId.Add(enumDefinition.SaveId, enumDefinition);
		_allTypeDefinitions.Add(enumDefinition.Type, enumDefinition);
		_allTypeDefinitionsWithId.Add(enumDefinition.SaveId, enumDefinition);
	}

	internal void AddContainerDefinition(ContainerDefinition containerDefinition)
	{
		_containerDefinitions.Add(containerDefinition.Type, containerDefinition);
		_containerDefinitionsWithId.Add(containerDefinition.SaveId, containerDefinition);
		_allTypeDefinitions.Add(containerDefinition.Type, containerDefinition);
		_allTypeDefinitionsWithId.Add(containerDefinition.SaveId, containerDefinition);
	}

	internal void AddBasicTypeDefinition(BasicTypeDefinition basicTypeDefinition)
	{
		_basicTypeDefinitions.Add(basicTypeDefinition.Type, basicTypeDefinition);
		_basicTypeDefinitionsWithId.Add(basicTypeDefinition.SaveId, basicTypeDefinition);
		_allTypeDefinitions.Add(basicTypeDefinition.Type, basicTypeDefinition);
		_allTypeDefinitionsWithId.Add(basicTypeDefinition.SaveId, basicTypeDefinition);
	}

	private void AddGenericClassDefinition(GenericTypeDefinition genericClassDefinition)
	{
		_genericClassDefinitions.Add(genericClassDefinition.Type, genericClassDefinition);
		_allTypeDefinitions.Add(genericClassDefinition.Type, genericClassDefinition);
		_allTypeDefinitionsWithId.Add(genericClassDefinition.SaveId, genericClassDefinition);
	}

	private void AddGenericStructDefinition(GenericTypeDefinition genericStructDefinition)
	{
		_genericStructDefinitions.Add(genericStructDefinition.Type, genericStructDefinition);
		_allTypeDefinitions.Add(genericStructDefinition.Type, genericStructDefinition);
		_allTypeDefinitionsWithId.Add(genericStructDefinition.SaveId, genericStructDefinition);
	}

	public void FillWithCurrentTypes()
	{
		_assemblies = GetSaveableAssemblies();
		Assembly[] assemblies = _assemblies;
		foreach (Assembly assembly in assemblies)
		{
			CollectTypes(assembly);
		}
		foreach (SaveableTypeDefiner saveableTypeDefiner in _saveableTypeDefiners)
		{
			saveableTypeDefiner.Initialize(this);
		}
		foreach (SaveableTypeDefiner saveableTypeDefiner2 in _saveableTypeDefiners)
		{
			saveableTypeDefiner2.DefineBasicTypes();
		}
		foreach (SaveableTypeDefiner saveableTypeDefiner3 in _saveableTypeDefiners)
		{
			saveableTypeDefiner3.DefineClassTypes();
		}
		foreach (SaveableTypeDefiner saveableTypeDefiner4 in _saveableTypeDefiners)
		{
			saveableTypeDefiner4.DefineStructTypes();
		}
		foreach (SaveableTypeDefiner saveableTypeDefiner5 in _saveableTypeDefiners)
		{
			saveableTypeDefiner5.DefineInterfaceTypes();
		}
		foreach (SaveableTypeDefiner saveableTypeDefiner6 in _saveableTypeDefiners)
		{
			saveableTypeDefiner6.DefineEnumTypes();
		}
		foreach (SaveableTypeDefiner saveableTypeDefiner7 in _saveableTypeDefiners)
		{
			saveableTypeDefiner7.DefineRootClassTypes();
		}
		foreach (SaveableTypeDefiner saveableTypeDefiner8 in _saveableTypeDefiners)
		{
			saveableTypeDefiner8.DefineGenericStructDefinitions();
		}
		foreach (SaveableTypeDefiner saveableTypeDefiner9 in _saveableTypeDefiners)
		{
			saveableTypeDefiner9.DefineGenericClassDefinitions();
		}
		foreach (SaveableTypeDefiner saveableTypeDefiner10 in _saveableTypeDefiners)
		{
			saveableTypeDefiner10.DefineContainerDefinitions();
		}
		foreach (TypeDefinition value in _rootClassDefinitions.Values)
		{
			value.CollectInitializationCallbacks();
			value.CollectProperties();
			value.CollectFields();
		}
		TWParallel.ForEach(_classDefinitions.Values, delegate(TypeDefinition classDefinition)
		{
			classDefinition.CollectInitializationCallbacks();
			classDefinition.CollectProperties();
			classDefinition.CollectFields();
		});
		foreach (TypeDefinition value2 in _classDefinitions.Values)
		{
			_errors.AddRange(value2.Errors);
		}
		TWParallel.ForEach(_structDefinitions.Values, delegate(StructDefinition structDefinitions)
		{
			structDefinitions.CollectProperties();
			structDefinitions.CollectFields();
		});
		foreach (StructDefinition value3 in _structDefinitions.Values)
		{
			_errors.AddRange(value3.Errors);
		}
		FindAutoGeneratedSaveManagers();
		InitializeAutoGeneratedSaveManagers();
	}

	private Assembly[] GetSaveableAssemblies()
	{
		List<Assembly> list = new List<Assembly>();
		Assembly assembly = typeof(SaveableRootClassAttribute).Assembly;
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		list.Add(assembly);
		Assembly[] array = assemblies;
		foreach (Assembly assembly2 in array)
		{
			if (!(assembly2 != assembly))
			{
				continue;
			}
			AssemblyName[] referencedAssemblies = assembly2.GetReferencedAssemblies();
			for (int j = 0; j < referencedAssemblies.Length; j++)
			{
				if (referencedAssemblies[j].ToString() == assembly.GetName().ToString())
				{
					list.Add(assembly2);
					break;
				}
			}
		}
		return list.ToArray();
	}

	private void CollectTypes(Assembly assembly)
	{
		foreach (Type item2 in assembly.GetTypesSafe())
		{
			if (typeof(SaveableTypeDefiner).IsAssignableFrom(item2) && !item2.IsAbstract)
			{
				SaveableTypeDefiner item = (SaveableTypeDefiner)Activator.CreateInstance(item2);
				_saveableTypeDefiners.Add(item);
			}
		}
	}

	internal TypeDefinitionBase GetTypeDefinition(Type type)
	{
		if (_allTypeDefinitions.TryGetValue(type, out var value))
		{
			return value;
		}
		return null;
	}

	internal TypeDefinition GetClassDefinition(Type type)
	{
		if (type.IsContainer())
		{
			return null;
		}
		if (_rootClassDefinitions.TryGetValue(type, out var value))
		{
			return value;
		}
		if (_genericClassDefinitions.TryGetValue(type, out var value2))
		{
			return value2;
		}
		if (_classDefinitions.TryGetValue(type, out var value3))
		{
			return value3;
		}
		return null;
	}

	public TypeDefinitionBase TryGetTypeDefinition(SaveId saveId)
	{
		if (_allTypeDefinitionsWithId.TryGetValue(saveId, out var value))
		{
			return value;
		}
		if (saveId is GenericSaveId)
		{
			GenericSaveId genericSaveId = (GenericSaveId)saveId;
			SaveId baseId = genericSaveId.BaseId;
			if (TryGetTypeDefinition(baseId) is TypeDefinition baseClassDefinition)
			{
				TypeDefinitionBase[] array = new TypeDefinitionBase[genericSaveId.GenericTypeIDs.Length];
				for (int i = 0; i < genericSaveId.GenericTypeIDs.Length; i++)
				{
					SaveId saveId2 = genericSaveId.GenericTypeIDs[i];
					TypeDefinitionBase typeDefinitionBase = TryGetTypeDefinition(saveId2);
					if (typeDefinitionBase == null)
					{
						return null;
					}
					array[i] = typeDefinitionBase;
				}
				Type type = ConstructTypeFrom(baseClassDefinition, array);
				if (type != null)
				{
					GenericTypeDefinition genericTypeDefinition = new GenericTypeDefinition(type, genericSaveId);
					genericTypeDefinition.CollectInitializationCallbacks();
					genericTypeDefinition.CollectFields();
					genericTypeDefinition.CollectProperties();
					if (genericTypeDefinition.IsClassDefinition)
					{
						if (!_allTypeDefinitions.ContainsKey(genericTypeDefinition.Type))
						{
							AddGenericClassDefinition(genericTypeDefinition);
						}
					}
					else
					{
						AddGenericStructDefinition(genericTypeDefinition);
					}
					return genericTypeDefinition;
				}
			}
		}
		return null;
	}

	internal GenericTypeDefinition ConstructGenericClassDefinition(Type type)
	{
		Type genericTypeDefinition = type.GetGenericTypeDefinition();
		TypeDefinition classDefinition = GetClassDefinition(genericTypeDefinition);
		TypeSaveId baseId = (TypeSaveId)classDefinition.SaveId;
		SaveId[] array = new SaveId[type.GenericTypeArguments.Length];
		for (int i = 0; i < type.GenericTypeArguments.Length; i++)
		{
			Type type2 = type.GenericTypeArguments[i];
			TypeDefinitionBase typeDefinition = GetTypeDefinition(type2);
			array[i] = typeDefinition.SaveId;
		}
		GenericSaveId saveId = new GenericSaveId(baseId, array);
		GenericTypeDefinition genericTypeDefinition2 = new GenericTypeDefinition(type, saveId);
		foreach (CustomField customField in classDefinition.CustomFields)
		{
			genericTypeDefinition2.AddCustomField(customField.Name, customField.SaveId);
		}
		genericTypeDefinition2.CollectInitializationCallbacks();
		genericTypeDefinition2.CollectFields();
		genericTypeDefinition2.CollectProperties();
		AddGenericClassDefinition(genericTypeDefinition2);
		return genericTypeDefinition2;
	}

	internal bool HasDefinition(Type type)
	{
		return _allTypeDefinitions.ContainsKey(type);
	}

	internal ContainerDefinition ConstructContainerDefinition(Type type, Assembly definedAssembly)
	{
		type.IsContainer(out var containerType);
		SaveId keyId = null;
		SaveId valueId = null;
		switch (containerType)
		{
		case ContainerType.List:
		case ContainerType.Queue:
		case ContainerType.CustomList:
		case ContainerType.CustomReadOnlyList:
		{
			Type type4 = type.GenericTypeArguments[0];
			keyId = GetTypeDefinition(type4).SaveId;
			break;
		}
		case ContainerType.Dictionary:
		{
			Type type2 = type.GenericTypeArguments[0];
			keyId = GetTypeDefinition(type2).SaveId;
			Type type3 = type.GenericTypeArguments[1];
			valueId = GetTypeDefinition(type3).SaveId;
			break;
		}
		case ContainerType.Array:
		{
			Type elementType = type.GetElementType();
			keyId = GetTypeDefinition(elementType).SaveId;
			break;
		}
		}
		ContainerSaveId saveId = new ContainerSaveId(containerType, keyId, valueId);
		ContainerDefinition containerDefinition = new ContainerDefinition(type, saveId, definedAssembly);
		AddContainerDefinition(containerDefinition);
		if (containerType == ContainerType.List)
		{
			AddContainerDefinition(new ContainerDefinition(typeof(MBList<>).MakeGenericType(type.GetGenericArguments()), new ContainerSaveId(ContainerType.CustomList, keyId, valueId), definedAssembly));
			AddContainerDefinition(new ContainerDefinition(typeof(MBReadOnlyList<>).MakeGenericType(type.GetGenericArguments()), new ContainerSaveId(ContainerType.CustomReadOnlyList, keyId, valueId), definedAssembly));
		}
		return containerDefinition;
	}

	private Type ConstructTypeFrom(TypeDefinition baseClassDefinition, TypeDefinitionBase[] parameterDefinitions)
	{
		Type type = baseClassDefinition.Type;
		Type[] array = new Type[parameterDefinitions.Length];
		for (int i = 0; i < parameterDefinitions.Length; i++)
		{
			Type type2 = parameterDefinitions[i].Type;
			if (type2 == null)
			{
				return null;
			}
			array[i] = type2;
		}
		return type.MakeGenericType(array);
	}

	internal TypeDefinition GetStructDefinition(Type type)
	{
		if (_genericStructDefinitions.TryGetValue(type, out var value))
		{
			return value;
		}
		if (_structDefinitions.TryGetValue(type, out var value2))
		{
			return value2;
		}
		return null;
	}

	internal InterfaceDefinition GetInterfaceDefinition(Type type)
	{
		_interfaceDefinitions.TryGetValue(type, out var value);
		return value;
	}

	internal EnumDefinition GetEnumDefinition(Type type)
	{
		_enumDefinitions.TryGetValue(type, out var value);
		return value;
	}

	internal ContainerDefinition GetContainerDefinition(Type type)
	{
		_containerDefinitions.TryGetValue(type, out var value);
		return value;
	}

	internal GenericTypeDefinition ConstructGenericStructDefinition(Type type)
	{
		Type genericTypeDefinition = type.GetGenericTypeDefinition();
		TypeDefinition structDefinition = GetStructDefinition(genericTypeDefinition);
		TypeSaveId baseId = (TypeSaveId)structDefinition.SaveId;
		SaveId[] array = new SaveId[type.GenericTypeArguments.Length];
		for (int i = 0; i < type.GenericTypeArguments.Length; i++)
		{
			Type type2 = type.GenericTypeArguments[i];
			TypeDefinitionBase typeDefinition = GetTypeDefinition(type2);
			array[i] = typeDefinition.SaveId;
		}
		GenericSaveId saveId = new GenericSaveId(baseId, array);
		GenericTypeDefinition genericTypeDefinition2 = new GenericTypeDefinition(type, saveId);
		foreach (CustomField customField in structDefinition.CustomFields)
		{
			genericTypeDefinition2.AddCustomField(customField.Name, customField.SaveId);
		}
		genericTypeDefinition2.CollectFields();
		genericTypeDefinition2.CollectProperties();
		AddGenericStructDefinition(genericTypeDefinition2);
		return genericTypeDefinition2;
	}

	internal BasicTypeDefinition GetBasicTypeDefinition(Type type)
	{
		_basicTypeDefinitions.TryGetValue(type, out var value);
		return value;
	}

	private void FindAutoGeneratedSaveManagers()
	{
		Assembly[] assemblies = _assemblies;
		for (int i = 0; i < assemblies.Length; i++)
		{
			foreach (Type item2 in assemblies[i].GetTypesSafe())
			{
				if (typeof(IAutoGeneratedSaveManager).IsAssignableFrom(item2) && typeof(IAutoGeneratedSaveManager) != item2)
				{
					IAutoGeneratedSaveManager item = (IAutoGeneratedSaveManager)Activator.CreateInstance(item2);
					_autoGeneratedSaveManagers.Add(item);
				}
			}
		}
	}

	private void InitializeAutoGeneratedSaveManagers()
	{
		foreach (IAutoGeneratedSaveManager autoGeneratedSaveManager in _autoGeneratedSaveManagers)
		{
			autoGeneratedSaveManager.Initialize(this);
		}
	}

	public void GenerateCode(SaveCodeGenerationContext context)
	{
		foreach (TypeDefinition value in _classDefinitions.Values)
		{
			Assembly assembly = value.Type.Assembly;
			context.FindAssemblyInformation(assembly)?.AddClassDefinition(value);
		}
		foreach (StructDefinition value2 in _structDefinitions.Values)
		{
			Assembly assembly2 = value2.Type.Assembly;
			context.FindAssemblyInformation(assembly2)?.AddStructDefinition(value2);
		}
		foreach (ContainerDefinition value3 in _containerDefinitions.Values)
		{
			Assembly definedAssembly = value3.DefinedAssembly;
			context.FindAssemblyInformation(definedAssembly)?.AddContainerDefinition(value3);
		}
		context.FillFiles();
	}
}
