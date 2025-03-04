<template>
  <div class="user-card">
    <h3>用户信息</h3>
    <div v-if="user">
      <p><strong>ID:</strong> {{ user.id }}</p>
      <p><strong>姓名:</strong> {{ user.name }}</p>
      <p><strong>邮箱:</strong> {{ user.email }}</p>
    </div>
    <div v-else>
      <p>正在加载用户信息...</p>
    </div>
  </div>
</template>
  
  <script setup lang="ts">
  import { ref, onMounted } from 'vue';
  import { getUser, type UserResponse } from '../api/userService';
  
  // 创建一个响应式变量 `user`
  const user = ref<UserResponse | null>(null);
  
  // 组件挂载时请求用户数据
  onMounted(async () => {
    try {
      user.value = await getUser(1); // 传入用户 ID
    } catch (error) {
      console.error('获取用户信息失败:', error);
    }
  });
  </script>
  
  <style scoped>
  .user-card {
    border: 1px solid #ddd;
    padding: 10px;
    border-radius: 5px;
    width: 300px;
  }
  </style>
  