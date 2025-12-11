# MaxQueueCalls Configuration Feature

**Date**: 2025-01-16 14:30  
**Version**: 1.0  
**Author**: GitHub Copilot

## Overview

Added a new configuration option `MaxQueueCalls` to limit the number of calls displayed in queue cards within the EventsPanel. This prevents UI overload when queues have many waiting calls.

## Problem Statement

When queues have many waiting calls (e.g., 20+ calls), the UI becomes cluttered and difficult to read. Users requested a configurable limit to show only the most relevant calls.

## Solution

### 1. New Configuration Property

Added `MaxQueueCalls` property to `EventsPanelOptions`:

```csharp
/// <summary>
/// Maximum number of calls to display in queue cards <br />
/// 0 = unlimited, default = 5 <br />
/// When limit is exceeded, shows the oldest calls (longest waiting time)
/// </summary>
[JsonPropertyName("maxqueuecalls")]
[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
public int MaxQueueCalls { get; set; } = 5;
```

**Default Value**: 5 calls  
**Special Value**: 0 = unlimited (shows all calls)

### 2. Implementation in CardChannels Component

Modified `CardChannels.razor.cs` to filter and sort calls:

```csharp
protected ChannelInfoCollection GetChannelsToDisplay()
{
    if (Channels == null || !Channels.Any())
     return new ChannelInfoCollection();

    // For queues, apply MaxQueueCalls limit
    if (Kind == EventsPanelCardKind.QUEUE)
    {
 var maxCalls = EPService?.Options?.MaxQueueCalls ?? 5;
  
     // If maxCalls is 0, show all
  if (maxCalls <= 0)
     return Channels;

        // Order by oldest first (longest waiting time) and take the limit
        var limitedChannels = Channels
            .OrderBy(c => c.Content?.Created ?? System.DateTime.MaxValue)
            .Take(maxCalls);

        var result = new ChannelInfoCollection();
        foreach (var channel in limitedChannels)
        {
      result.Add(channel);
        }
        return result;
    }

    // For other card types, return all channels
    return Channels;
}
```

### 3. Sorting Logic

Calls are sorted by **oldest first** (longest waiting time):
- Uses `Content.Created` timestamp
- Shows calls that have been waiting the longest
- Ensures important (long-waiting) calls are always visible

## Configuration

### appsettings.json

```json
{
  "Sufficit": {
    "Telephony": {
      "EventsPanel": {
        "MaxQueueCalls": 5,
        "MaxButtons": 50,
        "AutoFill": true,
        "RefreshRate": 0,
   "OnlyPeers": false
      }
    }
  }
}
```

### Configuration Options

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `MaxQueueCalls` | int | 5 | Maximum calls to display in queue cards |
| `MaxButtons` | int | 0 | Maximum number of buttons/cards to display |
| `AutoFill` | bool | false | Automatically add cards for all queues |
| `RefreshRate` | uint | 0 | UI refresh rate in milliseconds (0 = real-time) |
| `OnlyPeers` | bool? | null | Show only peer cards |

## Behavior Examples

### Example 1: Default Configuration (MaxQueueCalls = 5)

**Queue has 10 waiting calls:**
- Shows 5 oldest calls (longest waiting time)
- Remaining 5 calls are hidden but still tracked

### Example 2: Unlimited (MaxQueueCalls = 0)

**Queue has 10 waiting calls:**
- Shows all 10 calls
- No filtering applied

### Example 3: Custom Limit (MaxQueueCalls = 3)

**Queue has 8 waiting calls:**
- Shows 3 oldest calls
- Remaining 5 calls are hidden

## Impact on Other Card Types

This feature **only affects queue cards** (`EventsPanelCardKind.QUEUE`).

Other card types (Peers, Trunks) remain unaffected and continue to show all channels.

## Files Modified

1. **sufficit-telephony-eventspanel-core\src\EventsPanelOptions.cs**
   - Added `MaxQueueCalls` property
   - Updated `Equals()` and `GetHashCode()` methods

2. **sufficit-telephony-eventspanel-components\src\CardChannels.razor.cs**
   - Added `GetChannelsToDisplay()` method
   - Injected `IEventsPanelService` to access options
   - Added `Dispose()` to clean up event handlers

3. **sufficit-telephony-eventspanel-components\src\CardChannels.razor**
   - Updated to use `GetChannelsToDisplay()` instead of `Channels`

4. **sufficit-blazor\server\appsettings.json**
   - Added EventsPanel configuration example

5. **sufficit-blazor\server\appsettings.Development.json**
   - Added EventsPanel configuration example

## Testing Recommendations

1. **Test with different limits:**
   - MaxQueueCalls = 0 (unlimited)
   - MaxQueueCalls = 3 (small limit)
   - MaxQueueCalls = 10 (large limit)

2. **Test sorting:**
   - Verify oldest calls appear first
   - Confirm new calls don't bump old ones

3. **Test edge cases:**
   - Queue with 0 calls
   - Queue with exactly MaxQueueCalls calls
   - Queue with 1 call more than limit

4. **Test configuration:**
   - Verify appsettings.json is loaded correctly
   - Test default value when not configured

## Future Enhancements

Potential improvements for future versions:

1. **Dynamic sorting options:**
   - Sort by priority
   - Sort by caller ID
   - Sort by queue position

2. **Per-queue configuration:**
   - Allow different limits for different queues
   - Queue-specific sorting rules

3. **Visual indicators:**
- Show "X more calls waiting" when limit is exceeded
   - Add scroll/pagination for hidden calls

4. **Performance metrics:**
   - Track average wait time
   - Highlight calls exceeding SLA

## Support

For questions or issues, contact:
- **Development**: development@sufficit.com.br
- **Documentation**: [Internal Wiki](https://wiki.sufficit.com.br)

## License

© 2025 Sufficit Soluções em Tecnologia da Informação - All Rights Reserved
