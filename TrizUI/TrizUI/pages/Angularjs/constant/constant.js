/**
 *
 */
angular.module("myApp")

// 公司行业
    .constant('ImproveCharacterDictionary', [
 { id: 48, name: '1 运动物体的重量' },
 { id: 49, name: '2 静止物体的重量' },
 { id: 50, name: '3 运动物体的长度' },
 { id: 51, name: '4 静止物体的长度' },
 { id: 52, name: '5 运动物体的面积' },
 { id: 53, name: '6 静止物体的面积' },
 { id: 54, name: '7 运动物体的体积 ' },

 { id: 55, name: '8 静止物体的体积' },

 { id: 56, name: '9 速度' },

 { id: 57, name: '10 力' },

 { id: 58, name: '11 应力或压力' },

 { id: 60, name: '12 形状' },

 { id: 61, name: '13 结构的稳定性' },

 { id: 62, name: '14 强度' },

 { id: 63, name: '15 运动物体作用时间' },

 { id: 64, name: '16 静止物体作用时间' },

 { id: 65, name: '17 温度' },

 { id: 66, name: '18 光照强度' },

 { id: 67, name: '19 运动物体的能量' },

 { id: 68, name: '20 静止物体的能量' },

 { id: 69, name: '21 功率' },

 { id: 70, name: '22 能量损失' },

 { id: 71, name: '23 物质损失' },

 { id: 72, name: '24 信息损失' },

 { id: 73, name: '25 时间损失' },

 { id: 74, name: '26  物质或事物的数量' },

 { id: 75, name: '27 可靠性' },

 { id: 76, name: '28 测试精度' },

 { id: 77, name: '29 制造精度' },

 { id: 78, name: '30 物体外部有害因素作用的敏感性' },

 { id: 79, name: '31 物体产生的有害因素' },

 { id: 80, name: '32 可制造性' },

 { id: 81, name: '33 可操作性' },

 { id: 82, name: '34 可维修性' },

 { id: 83, name: '35 适应性及多用性' },

 { id: 84, name: '36 装置的复杂性' },

 { id: 85, name: '37 监控与测试的困难程度' },

 { id: 86, name: '38 自动化程度' },

 { id: 87, name: '39 生产率' }
    ])
    // 融资规模
    .constant('financing', [
        { id: 0, name: '无需融资' },
        { id: 1, name: '天使轮' },
        { id: 2, name: 'A轮' },
        { id: 3, name: 'B轮' },
        { id: 4, name: 'C轮' },
        { id: 5, name: 'D轮及以上' },
        { id: 6, name: '上市公司' }
    ])
    // 公司行业多选数据
    .constant('companyIndustryGroup', [
        { industry: 0, name: '移动互联网' },
        { industry: 1, name: '电子商务' },
        { industry: 2, name: '企业服务 ' },
        { industry: 3, name: 'O2O' },
        { industry: 4, name: '教育' },
        { industry: 5, name: '金融' },
        { industry: 6, name: '游戏' }
    ]);