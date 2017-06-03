/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

#if !BESTHTTP_DISABLE_SOCKETIO

namespace BestHTTP.SocketIO
{
    /// <summary>
    /// Possible event types on the transport level.
    /// </summary>
    public enum TransportEventTypes : int
    {
        Unknown = -1,
        Open = 0,
        Close = 1,
        Ping = 2,
        Pong = 3,
        Message = 4,
        Upgrade = 5,
        Noop = 6
    }

    /// <summary>
    /// Event types of the SocketIO protocol.
    /// </summary>
    public enum SocketIOEventTypes : int
    {
        Unknown = -1,

        /// <summary>
        /// Connect to a napespace, or we connected to a namespace
        /// </summary>
        Connect = 0,

        /// <summary>
        /// Disconnect a namespace, or we disconnected from a namespace.
        /// </summary>
        Disconnect = 1,

        /// <summary>
        /// A general event. The event's name is in the payload.
        /// </summary>
        Event = 2,

        /// <summary>
        /// Acknowledgement of an event.
        /// </summary>
        Ack = 3,

        /// <summary>
        /// Error sent by the server, or by the plugin
        /// </summary>
        Error = 4,

        /// <summary>
        /// A general event with binary attached to the packet. The event's name is in the payload.
        /// </summary>
        BinaryEvent = 5,

        /// <summary>
        /// Acknowledgement of a binary event.
        /// </summary>
        BinaryAck = 6
    }

    /// <summary>
    /// Possible error codes that the SocketIO server can send.
    /// </summary>
    public enum SocketIOErrors
    {
        /// <summary>
        /// Transport unknown
        /// </summary>
        UnknownTransport = 0,

        /// <summary>
        /// Session ID unknown
        /// </summary>
        UnknownSid = 1,

        /// <summary>
        /// Bad handshake method
        /// </summary>
        BadHandshakeMethod = 2,

        /// <summary>
        /// Bad request
        /// </summary>
        BadRequest = 3,

        /// <summary>
        /// Plugin internal error!
        /// </summary>
        Internal,

        /// <summary>
        /// Exceptions that caught by the plugin but raised in a user code.
        /// </summary>
        User,

        /// <summary>
        /// A custom, server sent error, most probably from a Socket.IO middleware.
        /// </summary>
        Custom,
    }
}

#endif
