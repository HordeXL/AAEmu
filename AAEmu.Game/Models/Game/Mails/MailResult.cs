namespace AAEmu.Game.Models.Game.Mails;

// There are many repetitions with ErrorMessageType
public enum MailResult : byte
{
    // 0 成功
    Success = 0,

    // 1 金币不足
    InsufficientCoins = 1,

    // 2 无法邮寄
    CanNotBeMailed = 2,

    // 3 插槽无效
    InvalidSlot = 3,

    // 4 找不到邮件
    CanNotFindMail = 4,

    // 5 无附件金钱
    NoAttachedMoney = 5,

    // 无附件物品。
    NoAttachedItems = 6,

    // 金币不足
    InsufficientCoins_2 = 7,

    // 不允许退回。
    ReturnsNotAllowed = 8,

    // 主题长度受限。
    SubjectLengthLimited = 9,

    // 文本长度受限。

    TextLengthLimited = 10,

    // 邮件未初始化。
    MailNotInitialized = 11,

    // 信件格式无效。
    InvalidLetterFormat = 12,

    // 物品信息不正确；请检查你的背包。
    IncorrectItemInformation = 13,

    // 无法访问选中的邮件。
    UnableToAccessSelectedMail = 14,

    // 找不到收件人。
    UnableToFindRecipient = 15,

    // 附近没有邮箱。
    NoMailboxNearby = 16,

    // 金币不足
    InsufficientCoins_3 = 17,

    // 功能维护中。
    FeatureUnderMaintenance = 18,

    // 绑定物品。
    BoundItem = 19,

    // 免费试用不可用。
    NotAvailableInFreeTrial = 20,

    // 免费账户不可用。
    NotAvailableForFreeAccounts = 21,

    // 等级太低。
    LevelTooLow = 22,

    // 必须先付费。
    YouMustPayFirst = 23,

    // 角色转移服务器时无法接收带附件的邮件。
    CharactersTransferringServers = 24,

    // 需要二级密码。
    SecondaryPasswordRequired = 25,

    // 物品已锁定。
    ItemLocked = 26,

    // 你无法执行任何敏感账户操作。
    CannotPerformSensitiveActions = 27,

    // 发送邮件过于频繁。请稍后再试。
    SendingMailsTooFrequent = 28,

    // 你已连续发送相同邮件 3 次或更多次。请稍后再试。
    SentSameMailTooManyTimes = 29,

    // 发生邮件错误。
    MailErrorOccurred = 30
}
