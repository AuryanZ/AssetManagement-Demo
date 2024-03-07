import Link from 'next/link';
import { navBarItems } from './navBarItems';

const VerticalNavBar = () => {
    return (
        <div className="vertical-nav-bar p-4">
            <ul className="space-y-4">
                {navBarItems.map((item, index) => (
                    <li key={index}>
                        <Link href={item.path} className='font-bold text-lg text-white hover:text-[#cbd5e1]'>
                            {item.title}
                        </Link>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default VerticalNavBar;
