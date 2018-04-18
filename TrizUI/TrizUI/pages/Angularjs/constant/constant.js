/**
 *
 */
angular.module("myApp")

// 冲突解决-提高特性和恶化特性
    .constant('ImproveCharacterDictionary', [
 { id: 1, name: '1 运动物体的重量' },
 { id: 2, name: '2 静止物体的重量' },
 { id: 3, name: '3 运动物体的长度' },
 { id: 4, name: '4 静止物体的长度' },
 { id: 5, name: '5 运动物体的面积' },
 { id: 6, name: '6 静止物体的面积' },
 { id: 7, name: '7 运动物体的体积 ' },
 { id: 8, name: '8 静止物体的体积' },
 { id: 9, name: '9 速度' },

 { id: 10, name: '10 力' },

 { id: 11, name: '11 应力或压力' },

 { id: 12, name: '12 形状' },

 { id: 13, name: '13 结构的稳定性' },

 { id: 14, name: '14 强度' },

 { id: 15, name: '15 运动物体作用时间' },

 { id: 16, name: '16 静止物体作用时间' },

 { id: 17, name: '17 温度' },

 { id: 18, name: '18 光照强度' },

 { id: 19, name: '19 运动物体的能量' },

 { id: 20, name: '20 静止物体的能量' },

 { id: 21, name: '21 功率' },

 { id: 22, name: '22 能量损失' },

 { id: 23, name: '23 物质损失' },

 { id: 24, name: '24 信息损失' },

 { id: 25, name: '25 时间损失' },

 { id: 26, name: '26  物质或事物的数量' },

 { id: 27, name: '27 可靠性' },

 { id: 28, name: '28 测试精度' },

 { id: 29, name: '29 制造精度' },

 { id: 30, name: '30 物体外部有害因素作用的敏感性' },

 { id: 31, name: '31 物体产生的有害因素' },

 { id: 32, name: '32 可制造性' },

 { id: 33, name: '33 可操作性' },

 { id: 34, name: '34 可维修性' },

 { id: 35, name: '35 适应性及多用性' },

 { id: 36, name: '36 装置的复杂性' },

 { id: 37, name: '37 监控与测试的困难程度' },

 { id: 38, name: '38 自动化程度' },

 { id: 39, name: '39 生产率' }
    ])
    //Dictionary TreeTypeID 只是描述，目前没有使用这个变量
    .constant('TreeTypeID', [
        { id: 1, name: '技术冲突解决' },
        { id: 2, name: '物理冲突解决' },
        { id: 3, name: '标准解' },
        { id: 4, name: '技术进化' },
        { id: 5, name: '' },
        { id: 6, name: '' }
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