﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Adnc.Infr.Mq.RabbitMq
{
    public class ExchageConfig
    {
        public string Name { get; set; }
        public ExchangeType Type { get; set; }
        public string DeadExchangeName { get; set; }
    }
}
