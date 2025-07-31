using System;
using System.Threading;

public class MessageIdGenerator
{
    private static int _counter = 99; // 初始化为99，因为第一次调用会递增到100
    private static string _lastDateTimePart = string.Empty;
    private static readonly object _lockObject = new object();

    public static long GenerateMessageId()
    {
        string dateTimePart = DateTime.Now.ToString("yyyyMMddHHmmss");
        int currentCounter;

        lock (_lockObject)
        {
            // 如果秒部分变化了，重置计数器
            if (dateTimePart != _lastDateTimePart)
            {
                _lastDateTimePart = dateTimePart;
                _counter = 99; // 重置为99，下一次递增到100
            }

            // 递增计数器，确保在100-999范围内循环
            if (_counter >= 999)
            {
                _counter = 99; // 重置为99，下一次递增到100
            }
            currentCounter = Interlocked.Increment(ref _counter);
        }

        // 转换为长整型返回
        return long.Parse($"{dateTimePart}{currentCounter:D3}");
    }
}