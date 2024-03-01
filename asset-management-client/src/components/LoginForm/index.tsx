'use client';
import { useEffect, useState } from 'react'
import { useRouter } from 'next/navigation'
import { loginfunc } from '@/api/auth/login';
import { getUserRole } from '@/api/auth/getUserRole';
import login from '@/app/auth/login/page';

export default function LoginForm() {

  const [error, setError] = useState('');
  const [seccess, setSeccess] = useState('');
  const router = useRouter();

  useEffect(() => {
    if (localStorage.getItem('Account')) {
      router.push('/');
    }
  }, [router])

  async function loginSubmit(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault();

    const loginData = new FormData(e.currentTarget);
    try {
      var loginTokenData = await loginfunc(loginData)
      if (loginTokenData.success === true) {
        setSeccess('Login successful');
        setError('');

        const accessToken = loginTokenData.accessToken?.toString(); // Add null check here
        const userRole = (accessToken ? await getUserRole(accessToken) : null).message; // Add null check here
        const expiration = loginTokenData.expiration;
        // console.log(loginTokenData)
        //Get user input from loginData
        loginTokenData.userRole = userRole;
        loginTokenData.userName = loginData.get('username');

        //Set token expiration time to 30 minutes later from now

        // loginTokenData.tokenExpirTime = Date.now();
        // console.log(loginTokenData.tokenExpirTime)
        delete loginTokenData.message;
        delete loginTokenData.success;
        delete loginTokenData.expiration;

        // console.log(loginTokenData)


        await localStorage.setItem('Account', JSON.stringify(loginTokenData));

        // if (userRole === 'user') { // Add null check here
        //   router.push('/dashboard/user');
        // } else if (userRole === 'admin') {
        //   router.push('/dashboard/admin');
        // }
        router.push('/');
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