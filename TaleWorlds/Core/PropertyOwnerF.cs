using System;
using System.Collections.Generic;
using System.Xml;
using TaleWorlds.Library;
using TaleWorlds.ObjectSystem;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.Core;

public class PropertyOwnerF<T> : MBObjectBase where T : MBObjectBase
{
	[SaveableField(10)]
	protected Dictionary<T, float> _attributes;

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
		collectedObjects.Add(_attributes);
	}

	public PropertyOwnerF()
	{
		_attributes = new Dictionary<T, float>();
	}

	public PropertyOwnerF(PropertyOwnerF<T> propertyOwner)
	{
		_attributes = new Dictionary<T, float>(propertyOwner._attributes);
	}

	public void SetPropertyValue(T attribute, float value)
	{
		if (!value.ApproximatelyEqualsTo(0f))
		{
			_attributes[attribute] = value;
		}
		else if (HasProperty(attribute))
		{
			_attributes.Remove(attribute);
		}
	}

	public float GetPropertyValue(T attribute)
	{
		if (attribute != null)
		{
			if (!_attributes.TryGetValue(attribute, out var value))
			{
				return 0f;
			}
			return value;
		}
		Debug.FailedAssert("attribute in GetPropertyValue can not be null!", "C:\\Develop\\MB3\\Source\\Bannerlord\\TaleWorlds.Core\\PropertyOwner.cs", "GetPropertyValue", 146);
		return 0f;
	}

	public bool HasProperty(T attribute)
	{
		return _attributes.ContainsKey(attribute);
	}

	public void ClearAllProperty()
	{
		_attributes.Clear();
	}

	public void Serialize(XmlWriter writer)
	{
		writer.WriteStartElement("attributes");
		foreach (KeyValuePair<T, float> attribute in _attributes)
		{
			writer.WriteStartElement("attribute");
			writer.WriteAttributeString("id", attribute.Key.StringId);
			writer.WriteAttributeString("value", attribute.Value.ToString());
			writer.WriteEndElement();
		}
		writer.WriteEndElement();
	}

	public override void Deserialize(MBObjectManager objectManager, XmlNode node)
	{
		Initialize();
		foreach (XmlNode childNode in node.ChildNodes)
		{
			if (!(childNode.Name == "attributes"))
			{
				continue;
			}
			foreach (XmlNode childNode2 in childNode.ChildNodes)
			{
				if (childNode2.Name == "attribute")
				{
					string innerText = childNode2.Attributes["id"].InnerText;
					if (innerText.Substring(0, innerText.IndexOf('.')).Equals("Attrib"))
					{
						T attribute = objectManager.ReadObjectReferenceFromXml("id", typeof(T), childNode2) as T;
						int num = Convert.ToInt32(childNode2.Attributes["value"].Value);
						SetPropertyValue(attribute, num);
					}
				}
			}
		}
	}
}
