<template>
  <div class="container">
    <h2>gRPC 用户查询</h2>
    
    <!-- 输入用户ID -->
    <input type="number" v-model="userId" placeholder="输入用户ID" />
    <button @click="fetchUser">查询用户</button>

    <!-- 显示用户信息 -->
    <UserCard v-if="user" :user="user" />
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { getUser, type UserResponse } from '@/api/userService';
import UserCard from '@/components/UserCard.vue';

const userId = ref<number | null>(null);
const user = ref<UserResponse | null>(null);

const fetchUser = async () => {
  if (!userId.value) {
    alert('请输入用户ID');
    return;
  }

  try {
    user.value = await getUser(userId.value);
  } catch (error) {
    alert('查询失败，请检查后端是否启动！');
  }
};
</script>
