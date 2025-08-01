using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

/// <summary>
/// 对象属性映射工具，用于自动复制两个对象间的同名属性
/// 兼容C# 7.3及以下版本
/// </summary>
public static class ObjectMapper
{
    /// <summary>
    /// 将源对象的属性值复制到目标对象
    /// </summary>
    /// <typeparam name="TSource">源对象类型</typeparam>
    /// <typeparam name="TTarget">目标对象类型</typeparam>
    /// <param name="source">源对象</param>
    /// <param name="target">目标对象</param>
    /// <param name="ignoreProperties">需要忽略的属性名列表</param>
    /// <param name="customMappings">自定义属性映射（键：源属性名，值：目标属性名）</param>
    public static void Map<TSource, TTarget>(TSource source, TTarget target,
        List<string> ignoreProperties = null,
        Dictionary<string, string> customMappings = null)
        where TSource : class
        where TTarget : class
    {
        if (source == null || target == null)
            throw new ArgumentNullException("源对象或目标对象不能为null");

        // 获取源对象和目标对象的属性信息
        var sourceProps = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanRead)
            .ToDictionary(p => p.Name.ToLower()); // 不区分大小写匹配

        var targetProps = typeof(TTarget).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanWrite)
            .ToList();

        // 处理需要忽略的属性（兼容C# 7.3，替换??=运算符）
        if (ignoreProperties == null)
        {
            ignoreProperties = new List<string>();
        }
        var ignorePropsLower = ignoreProperties.Select(p => p.ToLower()).ToList();

        // 处理自定义映射（兼容C# 7.3，替换??=运算符）
        if (customMappings == null)
        {
            customMappings = new Dictionary<string, string>();
        }
        var customMappingsLower = new Dictionary<string, string>();
        foreach (var item in customMappings)
        {
            customMappingsLower.Add(item.Key.ToLower(), item.Value.ToLower());
        }

        foreach (var targetProp in targetProps)
        {
            var targetPropNameLower = targetProp.Name.ToLower();

            // 跳过需要忽略的属性
            if (ignorePropsLower.Contains(targetPropNameLower))
                continue;

            // 查找源属性（优先使用自定义映射）
            PropertyInfo sourceProp;
            if (customMappingsLower.TryGetValue(targetPropNameLower, out var mappedSourceName))
            {
                if (!sourceProps.TryGetValue(mappedSourceName, out sourceProp))
                    continue; // 自定义映射未找到对应源属性，跳过
            }
            else
            {
                // 按名称匹配
                if (!sourceProps.TryGetValue(targetPropNameLower, out sourceProp))
                    continue; // 未找到同名属性，跳过
            }

            // 检查属性类型是否兼容
            if (IsTypeCompatible(sourceProp.PropertyType, targetProp.PropertyType))
            {
                try
                {
                    var value = sourceProp.GetValue(source);
                    targetProp.SetValue(target, value);
                }
                catch (Exception ex)
                {
                    // 记录复制失败的属性（可替换为日志框架）
                    Console.WriteLine($"属性复制失败：{sourceProp.Name} -> {targetProp.Name}，原因：{ex.Message}");
                }
            }
        }
    }

    /// <summary>
    /// 检查源类型是否可赋值给目标类型
    /// </summary>
    private static bool IsTypeCompatible(Type sourceType, Type targetType)
    {
        // 类型相同直接兼容
        if (sourceType == targetType)
            return true;

        // 可空类型处理
        var underlyingSourceType = Nullable.GetUnderlyingType(sourceType) ?? sourceType;
        var underlyingTargetType = Nullable.GetUnderlyingType(targetType) ?? targetType;

        // 值类型兼容检查
        if (underlyingSourceType.IsValueType && underlyingTargetType.IsValueType)
            return underlyingSourceType == underlyingTargetType;

        // 引用类型兼容检查（是否为继承关系）
        return targetType.IsAssignableFrom(sourceType);
    }
}

/// <summary>
/// 集合对象复制扩展方法
/// </summary>
public static class ObjectMapperExtensions
{
    /// <summary>
    /// 将源集合复制为目标类型集合
    /// </summary>
    public static List<TTarget> MapList<TSource, TTarget>(this IEnumerable<TSource> sourceList,
        List<string> ignoreProperties = null,
        Dictionary<string, string> customMappings = null)
        where TSource : class
        where TTarget : class, new()
    {
        // 兼容C# 7.3，替换空合并运算符
        if (sourceList == null)
        {
            return new List<TTarget>();
        }

        var result = new List<TTarget>();
        foreach (var source in sourceList)
        {
            var target = new TTarget();
            ObjectMapper.Map(source, target, ignoreProperties, customMappings);
            result.Add(target);
        }
        return result;
    }
}
