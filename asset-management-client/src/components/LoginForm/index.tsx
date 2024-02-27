'use client';
import { useEffect, useState } from 'react'
import { useRouter } from 'next/navigation'
import { loginfunc } from '@/api/auth/login';
import { getUserRole } from '@/api/auth/GetuserRole';

export default function LoginForm() {

  const [error, setError] = useState('');
  const [seccess, setSeccess] = useState('');
  // const [accessToken, setAccessToken] = useState('');
  // const [refreshToken, setRefreshToken] = useState('');
  // const [tokenExpiry, setTokenExpiry] = useState('');
  // const [userRole, setUserRole] = useState('');
  const router = useRouter();

  async function loginSubmit(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault();

    const loginData = new FormData(e.currentTarget);
    try {
      console.log(loginData)
      var loginTokenData = await loginfunc(loginData)
      console.log(loginTokenData)
      if (loginTokenData.success === true) {
        setSeccess('Login successful');
        setError('');

        const accessToken = loginTokenData.accessToken?.toString(); // Add null check here
        const refreshToken = loginTokenData.refreshToken?.toString(); // Add null check here
        const tokenExpiry = loginTokenData.expiration; // Add null check here
        // setAccessToken(loginTokenData.accessToken?.toString());
        // setRefreshToken(loginTokenData.refreshToken?.toString());
        // setTokenExpiry(loginTokenData.expiration);
        const userRole = (accessToken ? await getUserRole(accessToken) : null).message; // Add null check here
        // setUserRole(_userRole.message)

        await localStorage.setItem('accessToken', JSON.stringify(accessToken));
        await localStorage.setItem('refreshToken', JSON.stringify(refreshToken));
        await localStorage.setItem('tokenExpiry', JSON.stringify(tokenExpiry));
        await localStorage.setItem('userRole', JSON.stringify(userRole));

        if (userRole === 'user') { // Add null check here
          router.push('/dashboard/user');
        } else if (userRole === 'admin') {
          router.push('/dashboard/admin');
        }
      } else {
        setError(loginTokenData.message)
      }
    } catch (error) {
      console.log('Invalid credentials');
      setError('user name or password incorrect!');
    }
  }

  return (
    <div className="block items-center justify-center">
      <p className="text-2l font-bold pb-3 text-[#4F5864] text-center">Login</p>
      <div className="block items-center justify-center">
        <form onSubmit={loginSubmit} className='block items-center justify-center'>
          <input
            type="text"
            name="username"
            placeholder='User Name or Email Address'
            className="text-black block bg-gray-100 text-left w-full px-4 py-2 my-8 rounded-md"
          />

          <input
            type="text"
            name="password"
            className="text-black block bg-gray-100 text-left w-full px-4 py-2 my-2 rounded-md"
            placeholder='Password'
          />
          {error ? (
            <p className="text-red-500 text-center">{error}</p>
          ) : (
            <p className="text-green-500 text-center">{seccess}</p>
          )}
          <button type="submit"
            className="bg-[#1EB3EC] rounded-full border-4 w-full px-32 py-1 text-white text-center">Login</button>

        </form>
      </div>
      <div className="signinreg-divider flex text-base items-center px-4 my-4">
        <div className="flex-1 h-px bg-gray-300 mr-4"></div>
        <div className="flex-1 h-px bg-gray-300 ml-4"></div>
      </div>


    </div>
  )
}